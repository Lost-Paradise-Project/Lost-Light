using System.Linq;
using Content.Server.Administration;
using Content.Shared._WL.ScreenCapture;
using Content.Shared.Administration;
using Robust.Server.Player;
using Robust.Shared.Console;

namespace Content.Server._WL.ScreenCapture.Commands;

public abstract partial class BaseCaptureScreenCommand : LocalizedEntityCommands
{
    [Dependency] private IPlayerManager _player = default!;
    [Dependency] private CaptureSystem _capture = default!;

    protected abstract PhotoCaptureType Type { get; }

    public override void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (shell.Player is null)
        {
            shell.WriteError(Loc.GetString("shell-only-players-can-run-this-command"));
            return;
        }

        if (args.Length != 1)
        {
            shell.WriteError(Loc.GetString("shell-wrong-arguments-number"));
            return;
        }

        if (!_player.TryGetSessionByUsername(args[0], out var session))
        {
            shell.WriteError(Loc.GetString("shell-target-player-does-not-exist"));
            return;
        }

        _capture.RequestScreenCapture(session, shell.Player, Type);
    }

    public override CompletionResult GetCompletion(IConsoleShell shell, string[] args)
    {
        if (args.Length == 1)
        {
            var names = _player.Sessions.OrderBy(c => c.Name).Select(c => c.Name).ToArray();
            return CompletionResult.FromHintOptions(names, Loc.GetString("shell-argument-username-hint"));
        }

        return CompletionResult.Empty;
    }
}

[AdminCommand(AdminFlags.Moderator)]
public sealed partial class CaptureScreenClydeCommand : BaseCaptureScreenCommand
{
    public override string Command => "capturescreenclyde";
    protected override PhotoCaptureType Type => PhotoCaptureType.Clyde;
}

[AdminCommand(AdminFlags.Moderator)]
public sealed partial class CaptureScreenViewportCommand : BaseCaptureScreenCommand
{
    public override string Command => "capturescreenviewport";
    protected override PhotoCaptureType Type => PhotoCaptureType.Viewport;
}
