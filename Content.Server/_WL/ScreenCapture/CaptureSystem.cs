using Content.Server.Administration.Logs;
using Content.Server.Administration.Managers;
using Content.Server.Chat.Managers;
using Content.Server.EUI;
using Content.Shared._WL.ScreenCapture;
using Content.Shared.Administration;
using Content.Shared.Database;
using Robust.Shared.Enums;
using Robust.Shared.Player;
using Robust.Shared.Timing;

namespace Content.Server._WL.ScreenCapture;

/// <summary>
/// Скринграб. Ответ клиента проверяется до показа админу: изменённый клиент может прислать картинку-бомбу.
/// </summary>
public sealed partial class CaptureSystem : EntitySystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private EuiManager _eui = default!;
    [Dependency] private IChatManager _chat = default!;
    [Dependency] private IAdminManager _admin = default!;
    [Dependency] private IAdminLogManager _adminLog = default!;

    private const int MaxImageBytes = 8 * 1024 * 1024;

    private const int MaxImageSide = 8192;

    // У админа картинка распаковывается в RGBA: 4096x4096 - это 64 МБ
    private const int MaxImagePixels = 4096 * 4096;

    private static readonly TimeSpan RequestUpdateInterval = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(20);

    private readonly List<CaptureScreenRequest> _requests = new();
    private TimeSpan _nextRequestUpdate = TimeSpan.Zero;
    private int _nextRequestId;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<CaptureScreenResponseEvent>(OnCaptureScreenResponse);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        if (_requests.Count == 0 || _timing.CurTime < _nextRequestUpdate)
            return;

        _nextRequestUpdate = _timing.CurTime + RequestUpdateInterval;

        for (var i = _requests.Count - 1; i >= 0; i--)
        {
            var request = _requests[i];

            if (request.RequestBy.Status == SessionStatus.Disconnected)
            {
                _requests.RemoveAt(i);
                continue;
            }

            if (request.Player.Status == SessionStatus.Disconnected)
            {
                Fail(request, "screen-capture-error-disconnected");
                _requests.RemoveAt(i);
                continue;
            }

            if (request.TimeoutTime >= _timing.CurTime)
                continue;

            Fail(request, "screen-capture-error-timeout");
            _requests.RemoveAt(i);
        }
    }

    public void RequestScreenCapture(ICommonSession session, ICommonSession requestBy, PhotoCaptureType type)
    {
        foreach (var existing in _requests)
        {
            if (existing.RequestBy != requestBy)
                continue;

            _chat.SendAdminAnnouncementMessage(requestBy, Loc.GetString("screen-capture-error-repeat-request"));
            return;
        }

        var request = new CaptureScreenRequest
        {
            Id = ++_nextRequestId,
            Player = session,
            RequestBy = requestBy,
            Type = type,
            TimeoutTime = _timing.CurTime + RequestTimeout,
        };

        _requests.Add(request);
        RaiseNetworkEvent(new CaptureScreenRequestEvent(request.Id, type), session);

        _adminLog.Add(LogType.AdminCommands, LogImpact.Medium,
            $"{requestBy.Name} ({requestBy.UserId}) requested a screen capture ({type}) of {session.Name} ({session.UserId})");
    }

    private void OnCaptureScreenResponse(CaptureScreenResponseEvent ev, EntitySessionEventArgs args)
    {
        var index = _requests.FindIndex(r => r.Id == ev.RequestId && r.Player == args.SenderSession);

        if (index == -1)
            return;

        var request = _requests[index];
        _requests.RemoveAt(index);

        if (!_admin.HasAdminFlag(request.RequestBy, AdminFlags.Moderator))
            return;

        if (ev.Image == null)
        {
            Fail(request, "screen-capture-error-client");
            return;
        }

        if (!IsValidImage(ev.Image))
        {
            Fail(request, "screen-capture-error-invalid");
            return;
        }

        var eui = new ImageEui(ev.Image, request.Player.Name, request.Type);
        _eui.OpenEui(eui, request.RequestBy);
        eui.StateDirty();
    }

    private static bool IsValidImage(byte[] data)
    {
        if (data.Length == 0 || data.Length > MaxImageBytes)
            return false;

        return TryReadJpegSize(data, out var width, out var height)
            && width is > 0 and <= MaxImageSide
            && height is > 0 and <= MaxImageSide
            && (long) width * height <= MaxImagePixels;
    }

    /// <summary>
    /// Размеры из маркера SOFn, без распаковки картинки.
    /// </summary>
    private static bool TryReadJpegSize(ReadOnlySpan<byte> data, out int width, out int height)
    {
        width = 0;
        height = 0;

        // SOI
        if (data.Length < 4 || data[0] != 0xFF || data[1] != 0xD8)
            return false;

        var pos = 2;
        while (pos + 4 <= data.Length)
        {
            if (data[pos] != 0xFF)
                return false;

            var marker = data[pos + 1];

            // Заполняющие 0xFF перед маркером
            if (marker == 0xFF)
            {
                pos++;
                continue;
            }

            // Маркеры без длины
            if (marker is 0x01 or (>= 0xD0 and <= 0xD7))
            {
                pos += 2;
                continue;
            }

            // EOI или начало данных скана до SOF - кадра нет
            if (marker is 0xD9 or 0xDA)
                return false;

            var length = (data[pos + 2] << 8) | data[pos + 3];
            if (length < 2 || pos + 2 + length > data.Length)
                return false;

            // SOF0-SOF15, кроме DHT (C4), JPG (C8) и DAC (CC)
            if (marker is >= 0xC0 and <= 0xCF and not 0xC4 and not 0xC8 and not 0xCC)
            {
                if (length < 7)
                    return false;

                height = (data[pos + 5] << 8) | data[pos + 6];
                width = (data[pos + 7] << 8) | data[pos + 8];
                return true;
            }

            pos += 2 + length;
        }

        return false;
    }

    private void Fail(CaptureScreenRequest request, LocId locId)
    {
        _chat.SendAdminAnnouncementMessage(request.RequestBy,
            Loc.GetString(locId, ("player", request.Player.Name)));

        _adminLog.Add(LogType.AdminCommands, LogImpact.Medium,
            $"Screen capture of {request.Player.Name} ({request.Player.UserId}) failed: {locId}");
    }

    private struct CaptureScreenRequest
    {
        public int Id;
        public ICommonSession RequestBy;
        public ICommonSession Player;
        public PhotoCaptureType Type;
        public TimeSpan TimeoutTime;
    }
}
