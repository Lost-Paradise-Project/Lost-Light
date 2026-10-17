using Robust.Shared.Serialization;

namespace Content.Shared._WL.ScreenCapture;

[Serializable, NetSerializable]
public enum PhotoCaptureType : byte
{
    Clyde = 0,
    Viewport = 1
}
