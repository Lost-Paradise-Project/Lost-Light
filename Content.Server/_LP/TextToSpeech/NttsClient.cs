using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Content.Server._Starlight.TextToSpeech;
using Content.Shared._Starlight.TextToSpeech;
using Content.Shared.CCVar;
using Robust.Shared.Configuration;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using EnumeratorCancellation = System.Runtime.CompilerServices.EnumeratorCancellationAttribute;

namespace Content.Server._LP.TextToSpeech;

/// <summary>
/// TTS через HTTP API ntts.fdev.team вместо воркера Starlight на Redis.
/// ntts отдаёт Ogg Vorbis целиком, клиент Starlight проигрывает его одним куском.
/// </summary>
public sealed partial class NttsClient : ITTSClient
{
    [Dependency] private IConfigurationManager _cfg = default!;
    [Dependency] private IHttpClientHolder _http = default!;
    [Dependency] private IPrototypeManager _prototype = default!;

    /// <summary>
    /// Голос объявлений по умолчанию в <see cref="TTSSystem"/>.
    /// </summary>
    private const int StarlightAnnounceVoice = 2001;

    private static readonly Dictionary<TTSEffect, string> Effects = new()
    {
        [TTSEffect.Radio] = "radio_headset",
        [TTSEffect.Walkie] = "walkie_talkie",
        [TTSEffect.Phone] = "telephone",
        [TTSEffect.Megaphone] = "announce",
        [TTSEffect.Underwater] = "tunnel",
        [TTSEffect.Mystical] = "ghost",
    };

    // Защита от сбоев ntts: не больше MaxParallel запросов одновременно, всего (в работе и в очереди) не больше MaxPending запросов,
    // после FailuresToTrip подряд сбоев сервиса запросы на TripDuration не уходят вовсе.
    private const int MaxParallel = 4;
    private const int MaxPending = 16;
    private const int FailuresToTrip = 3;
    private static readonly TimeSpan TripDuration = TimeSpan.FromSeconds(30);

    private readonly SemaphoreSlim _slots = new(MaxParallel);
    private readonly Dictionary<(string Speaker, TTSEffect Effect, string Text), Task<byte[]?>> _inflight = new();
    private int _waiting;
    private int _failures;
    private long _blockedUntil;

    private readonly Dictionary<int, string> _speakers = new();
    private readonly Dictionary<(string Speaker, TTSEffect Effect, string Text), LinkedListNode<CacheEntry>> _cache = new();
    private readonly LinkedList<CacheEntry> _cacheOrder = new();
    private readonly object _cacheLock = new();

    private ISawmill _sawmill = default!;
    private string _apiUrl = string.Empty;
    private string _apiToken = string.Empty;
    private int _timeout;
    private int _maxCache;
    private string _defaultSpeaker = string.Empty;
    private string _announceSpeaker = string.Empty;

    public void Initialize()
    {
        _sawmill = Logger.GetSawmill("ntts");

        _cfg.OnValueChanged(CCVars.TTSApiUrl, v => _apiUrl = v, true);
        _cfg.OnValueChanged(CCVars.TTSApiToken, v => _apiToken = v, true);
        _cfg.OnValueChanged(CCVars.TTSApiTimeout, v => _timeout = v, true);
        _cfg.OnValueChanged(CCVars.TTSMaxCache, SetMaxCache, true);
        _cfg.OnValueChanged(CCVars.TTSDefaultSpeaker, v => _defaultSpeaker = v, true);
        _cfg.OnValueChanged(CCVars.TTSAnnounceSpeaker, v => _announceSpeaker = v, true);

        _prototype.PrototypesReloaded += OnPrototypesReloaded;
    }

    public async IAsyncEnumerable<byte[]> GenerateTTS
    (
        string text,
        int voice,
        TTSEffect effect = TTSEffect.None,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        // Пустой массив в конце всегда: по нему клиент закрывает поток, иначе поток висит до конца раунда.
        text = NttsTextSanitizer.Sanitize(text);
        var speaker = GetSpeaker(voice);
        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(speaker) || string.IsNullOrEmpty(_apiUrl))
        {
            yield return [];
            yield break;
        }

        var key = (speaker, effect, text);
        var audio = GetCache(key) ?? await RequestShared(key);
        if (audio is not null)
        {
            AddCache(key, audio);
            yield return audio;
        }

        yield return [];
    }

    /// <summary>
    /// Одинаковые одновременные запросы (тот же голос, эффект и текст) делят один запрос к ntts.
    /// </summary>
    private Task<byte[]?> RequestShared((string Speaker, TTSEffect Effect, string Text) key)
    {
        lock (_inflight)
        {
            if (_inflight.TryGetValue(key, out var existing))
                return existing;

            var task = RequestLimited(key.Speaker, key.Text, key.Effect);
            _inflight[key] = task;
            task.ContinueWith(_ =>
            {
                lock (_inflight)
                {
                    _inflight.Remove(key);
                }
            }, TaskScheduler.Default);
            return task;
        }
    }

    private async Task<byte[]?> RequestLimited(string speaker, string text, TTSEffect effect)
    {
        if (Environment.TickCount64 < Interlocked.Read(ref _blockedUntil))
            return null;

        if (Interlocked.Increment(ref _waiting) > MaxPending)
        {
            Interlocked.Decrement(ref _waiting);
            return null;
        }

        var acquired = false;
        try
        {
            acquired = await _slots.WaitAsync(TimeSpan.FromSeconds(Math.Max(1, _timeout)));
            if (!acquired)
                return null;

            // Пауза могла включиться, пока запрос стоял в очереди
            if (Environment.TickCount64 < Interlocked.Read(ref _blockedUntil))
                return null;

            var (audio, serviceFault) = await Request(speaker, text, effect, CancellationToken.None);
            RegisterResult(serviceFault);
            return audio;
        }
        catch (Exception ex)
        {
            // Любой неожиданный сбой (обрыв чтения тела, кривой tts.api_url) не должен ронять поток: клиент ждёт пустой чанк
            _sawmill.Warning($"Сбой запроса к ntts: {ex.Message}");
            RegisterResult(true);
            return null;
        }
        finally
        {
            if (acquired)
                _slots.Release();

            Interlocked.Decrement(ref _waiting);
        }
    }

    private void RegisterResult(bool serviceFault)
    {
        if (!serviceFault)
        {
            Interlocked.Exchange(ref _failures, 0);
            return;
        }

        if (Interlocked.Increment(ref _failures) < FailuresToTrip)
            return;

        Interlocked.Exchange(ref _failures, 0);
        Interlocked.Exchange(ref _blockedUntil, Environment.TickCount64 + (long) TripDuration.TotalMilliseconds);
        _sawmill.Warning($"ntts недоступен, запросы приостановлены на {TripDuration.TotalSeconds:0} с");
    }

    /// <summary>
    /// Запрос к ntts. <c>ServiceFault</c> - сбой самого сервиса (таймаут, сеть, 5xx, 429), по нему включается пауза.
    /// Ошибки запроса (плохой голос или текст) сбоем не считаются.
    /// </summary>
    private async Task<(byte[]? Audio, bool ServiceFault)> Request(string speaker, string text, TTSEffect effect, CancellationToken cancellationToken)
    {
        var query = $"speaker={Uri.EscapeDataString(speaker)}&text={Uri.EscapeDataString(text)}&ext=ogg";
        if (Effects.TryGetValue(effect, out var effectName))
            query += $"&effect={effectName}";

        using var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}?{query}");
        if (!string.IsNullOrEmpty(_apiToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromSeconds(Math.Max(1, _timeout)));

        try
        {
            using var response = await _http.Client.SendAsync(request, cts.Token);
            if (!response.IsSuccessStatusCode)
            {
                _sawmill.Warning($"ntts ответил {(int) response.StatusCode} для голоса {speaker}: {await response.Content.ReadAsStringAsync(cts.Token)}");
                return (null, (int) response.StatusCode >= 500 || (int) response.StatusCode == 429);
            }

            var audio = await response.Content.ReadAsByteArrayAsync(cts.Token);
            if (audio.Length < 4 || audio[0] != 'O' || audio[1] != 'g' || audio[2] != 'g' || audio[3] != 'S')
            {
                _sawmill.Warning($"ntts вернул не ogg для голоса {speaker} ({audio.Length} байт, {response.Content.Headers.ContentType})");
                return (null, false);
            }

            return (audio, false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            _sawmill.Warning($"ntts не ответил за {_timeout} с для голоса {speaker}");
            return (null, true);
        }
        catch (HttpRequestException ex)
        {
            _sawmill.Warning($"Ошибка запроса к ntts: {ex.Message}");
            return (null, true);
        }
    }

    private string? GetSpeaker(int voice)
    {
        lock (_speakers)
        {
            if (_speakers.Count == 0)
                LoadSpeakers();

            if (_speakers.TryGetValue(voice, out var speaker))
                return speaker;
        }

        return voice == StarlightAnnounceVoice ? _announceSpeaker : _defaultSpeaker;
    }

    private void LoadSpeakers()
    {
        _speakers.Clear();
        foreach (var proto in _prototype.EnumeratePrototypes<VoicePrototype>())
        {
            if (proto.Speaker is { } speaker)
                _speakers[proto.Voice] = speaker;
        }
    }

    private void OnPrototypesReloaded(PrototypesReloadedEventArgs args)
    {
        if (!args.WasModified<VoicePrototype>())
            return;

        lock (_speakers)
        {
            LoadSpeakers();
        }
    }

    private void SetMaxCache(int value)
    {
        _maxCache = value;
        lock (_cacheLock)
        {
            TrimCache();
        }
    }

    private byte[]? GetCache((string, TTSEffect, string) key)
    {
        lock (_cacheLock)
        {
            if (!_cache.TryGetValue(key, out var node))
                return null;

            _cacheOrder.Remove(node);
            _cacheOrder.AddFirst(node);
            return node.Value.Audio;
        }
    }

    private void AddCache((string, TTSEffect, string) key, byte[] audio)
    {
        if (_maxCache <= 0)
            return;

        lock (_cacheLock)
        {
            if (_cache.ContainsKey(key))
                return;

            _cache[key] = _cacheOrder.AddFirst(new CacheEntry(key, audio));
            TrimCache();
        }
    }

    private void TrimCache()
    {
        while (_cacheOrder.Count > Math.Max(0, _maxCache))
        {
            var last = _cacheOrder.Last!;
            _cacheOrder.RemoveLast();
            _cache.Remove(last.Value.Key);
        }
    }

    private sealed record CacheEntry((string Speaker, TTSEffect Effect, string Text) Key, byte[] Audio);
}
