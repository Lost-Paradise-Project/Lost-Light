using Content.Shared.Eui;
using Robust.Shared.Serialization;

namespace Content.Shared._WL.ScreenCapture;

[Serializable, NetSerializable]
public sealed class CaptureScreenRequestEvent(int requestId, PhotoCaptureType type) : EntityEventArgs
{
    public int RequestId = requestId;
    public PhotoCaptureType Type = type;
}

/// <summary>
/// Ответ клиента: JPEG или null, если снять экран не получилось.
/// </summary>
[Serializable, NetSerializable]
public sealed class CaptureScreenResponseEvent(int requestId, byte[]? image) : EntityEventArgs
{
    public int RequestId = requestId;
    public byte[]? Image = image;
}

[Serializable, NetSerializable]
public sealed class ImageEuiState(byte[] image, string playerName, PhotoCaptureType type) : EuiStateBase
{
    public byte[] Image = image;
    public string PlayerName = playerName;
    public PhotoCaptureType Type = type;
}
