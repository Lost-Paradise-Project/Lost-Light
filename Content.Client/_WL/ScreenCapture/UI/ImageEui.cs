using Content.Client.Eui;
using Content.Shared._WL.ScreenCapture;
using Content.Shared.Eui;
using JetBrains.Annotations;

namespace Content.Client._WL.ScreenCapture.UI;

[UsedImplicitly]
public sealed partial class ImageEui : BaseEui
{
    private readonly ImageUi _window;

    public ImageEui()
    {
        _window = new ImageUi();
        _window.OnClose += () => SendMessage(new CloseEuiMessage());
    }

    public override void Opened()
    {
        _window.OpenCentered();
    }

    public override void Closed()
    {
        _window.Close();
    }

    public override void HandleState(EuiStateBase state)
    {
        if (state is not ImageEuiState cast)
            return;

        _window.SetImage(cast.Image, cast.PlayerName, cast.Type);
    }
}
