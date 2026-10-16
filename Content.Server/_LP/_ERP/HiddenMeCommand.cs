using Content.Server.Chat.Systems;
using Content.Shared.Administration;
using Content.Shared.Chat;
using Robust.Shared.Console;
using Robust.Shared.Enums;

namespace Content.Server._LP._ERP;

/// <summary>
/// Эмоция, которая не дублируется в чат (как me, но с <see cref="ChatTransmitRange.HideChat"/>).
/// </summary>
[AnyCommand]
public sealed partial class HiddenMeCommand : LocalizedEntityCommands
{
    [Dependency] private ChatSystem _chat = default!;

    public override string Command => "hme";

    public override void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (shell.Player is not { } player)
        {
            shell.WriteError(Loc.GetString("shell-cannot-run-command-from-server"));
            return;
        }

        if (player.Status != SessionStatus.InGame)
            return;

        if (player.AttachedEntity is not { } playerEntity)
        {
            shell.WriteError(Loc.GetString("shell-must-be-attached-to-entity"));
            return;
        }

        var message = string.Join(" ", args).Trim();
        if (string.IsNullOrEmpty(message))
            return;

        _chat.TrySendInGameICMessage(playerEntity, message, InGameICChatType.Emote, ChatTransmitRange.HideChat, false, shell, player);
    }
}
