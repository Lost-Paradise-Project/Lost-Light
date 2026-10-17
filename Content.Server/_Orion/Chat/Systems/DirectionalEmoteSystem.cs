using Content.Server.Administration.Logs;
using Content.Server.Chat.Managers;
using Content.Shared._Orion.Chat.Components;
using Content.Shared.CCVar;
using Content.Shared.Chat;
using Content.Shared.Database;
using Content.Shared.Examine;
using Robust.Shared.Configuration;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using Robust.Shared.Utility;

namespace Content.Server._Orion.Chat.Systems;

public sealed partial class DirectionalEmoteSystem : EntitySystem
{
    [Dependency] private IChatManager _chatManager = default!;
    [Dependency] private IGameTiming _gameTiming = default!;
    [Dependency] private ExamineSystemShared _examineSystem = default!;
    [Dependency] private IAdminLogManager _adminLogger = default!;
    [Dependency] private IConfigurationManager _cfg = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<SendDirectionalEmoteEvent>(OnSendDirectionalEmoteEvent);
    }

    private void OnSendDirectionalEmoteEvent(SendDirectionalEmoteEvent args, EntitySessionEventArgs session)
    {
        var text = args.Text.Trim();
        if (string.IsNullOrEmpty(text))
            return;

        if (session.SenderSession.AttachedEntity is not { } source ||
            !TryGetEntity(args.Target, out var target) ||
            source == target ||
            !TryComp<ActorComponent>(source, out var sourceActor) ||
            !TryComp<ActorComponent>(target, out var targetActor) ||
            !TryComp<DirectionalEmoteTargetComponent>(source, out var directEmote) ||
            !HasComp<DirectionalEmoteTargetComponent>(target))
            return;

        var curTime = _gameTiming.CurTime;
        if (directEmote.LastSend + directEmote.Cooldown > curTime)
            return;

        if (!_examineSystem.InRangeUnOccluded(source, target.Value, _cfg.GetCVar(CCVars.DirectionalEmoteRange)))
        {
            SendError(sourceActor, Loc.GetString("directional-emote-range-error"));
            return;
        }

        var maxLength = _cfg.GetCVar(CCVars.ChatMaxEmoteLength);
        if (text.Length > maxLength)
        {
            SendError(sourceActor, Loc.GetString("directional-emote-length-error", ("maxLength", maxLength)));
            return;
        }

        var wrappedMessage = Loc.GetString("chat-manager-entity-directional-emote-wrap-message",
            ("entityName", MetaData(source).EntityName),
            ("message", FormattedMessage.EscapeText(text)));

        _chatManager.ChatMessageToMany(ChatChannel.Emotes,
            text,
            wrappedMessage,
            source,
            false,
            true,
            [targetActor.PlayerSession.Channel, sourceActor.PlayerSession.Channel]);

        directEmote.LastSend = curTime;
        _adminLogger.Add(LogType.Chat,
            LogImpact.Low,
            $"{ToPrettyString(source):source} send directional emote to {ToPrettyString(target.Value):target}: {text}");
    }

    private void SendError(ActorComponent actor, string message)
    {
        _chatManager.ChatMessageToOne(ChatChannel.Emotes, message, message, default, false, actor.PlayerSession.Channel);
    }
}
