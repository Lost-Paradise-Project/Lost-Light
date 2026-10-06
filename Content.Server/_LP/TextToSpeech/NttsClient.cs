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
        var audio = GetCache(key) ?? await Request(speaker, text, effect, cancellationToken);
        if (audio is not null)
        {
            AddCache(key, audio);
            yield return audio;
        }

        yield return [];
    }

    private async Task<byte[]?> Request(string speaker, string text, TTSEffect effect, CancellationToken cancellationToken)
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
                return null;
            }

            var audio = await response.Content.ReadAsByteArrayAsync(cts.Token);
            if (audio.Length < 4 || audio[0] != 'O' || audio[1] != 'g' || audio[2] != 'g' || audio[3] != 'S')
            {
                _sawmill.Warning($"ntts вернул не ogg для голоса {speaker} ({audio.Length} байт, {response.Content.Headers.ContentType})");
                return null;
            }

            return audio;
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            _sawmill.Warning($"ntts не ответил за {_timeout} с для голоса {speaker}");
            return null;
        }
        catch (HttpRequestException ex)
        {
            _sawmill.Warning($"Ошибка запроса к ntts: {ex.Message}");
            return null;
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
