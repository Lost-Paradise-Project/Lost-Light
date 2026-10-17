using Content.Client.Popups;
using Content.Shared.Popups;
using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client._Orion.Chat.Systems.DirectionalEmote;

[UsedImplicitly]
public sealed class DirectionalEmoteUIController : UIController
{
    [UISystemDependency] private DirectionalEmoteSystem _directionalEmoteSystem = default!;
    [UISystemDependency] private PopupSystem _popup = default!;

    private DirectionalEmoteWindow? _emoteWindow;

    public void ToggleWindow(NetEntity source, NetEntity target)
    {
        if (_emoteWindow is { IsOpen: true })
        {
            _emoteWindow.Close();
            return;
        }

        _emoteWindow = CreateWindow(source, target);
        _emoteWindow.OpenCentered();
        _emoteWindow.MoveToFront();
    }

    private DirectionalEmoteWindow CreateWindow(NetEntity source, NetEntity target)
    {
        var window = UIManager.CreateWindow<DirectionalEmoteWindow>();
        window.Source = source;
        window.Target = target;

        window.AcceptPressed += () =>
        {
            var error = _directionalEmoteSystem.ShowMessage(window.Source, window.Target, window.Text);
            if (error != null)
            {
                _popup.PopupCursor(error, PopupType.SmallCaution);
                return;
            }

            window.Close();
        };

        window.OnClose += () => _emoteWindow = null;

        return window;
    }
}
