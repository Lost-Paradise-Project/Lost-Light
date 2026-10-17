using Content.Server.EUI;
using Content.Shared._WL.ScreenCapture;
using Content.Shared.Eui;

namespace Content.Server._WL.ScreenCapture;

public sealed partial class ImageEui : BaseEui
{
    private readonly byte[] _image;
    private readonly string _playerName;
    private readonly PhotoCaptureType _type;

    public ImageEui(byte[] image, string playerName, PhotoCaptureType type)
    {
        _image = image;
        _playerName = playerName;
        _type = type;
    }

    public override EuiStateBase GetNewState()
    {
        return new ImageEuiState(_image, _playerName, _type);
    }
}
