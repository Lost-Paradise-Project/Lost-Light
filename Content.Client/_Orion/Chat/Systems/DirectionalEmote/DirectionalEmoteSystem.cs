using Content.Shared._Orion.Chat.Components;
using Content.Shared.CCVar;
using Content.Shared.Verbs;
using Robust.Client.UserInterface;
using Robust.Shared.Configuration;
using Robust.Shared.Utility;

namespace Content.Client._Orion.Chat.Systems.DirectionalEmote;

public sealed partial class DirectionalEmoteSystem : EntitySystem
{
    [Dependency] private IUserInterfaceManager _userInterfaceManager = default!;
    [Dependency] private IConfigurationManager _cfg = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DirectionalEmoteTargetComponent, GetVerbsEvent<Verb>>(OnGetVerbs);
    }

    /// <summary>
    ///     Отправляет эмоцию на сервер. Возвращает причину отказа или null, если всё в порядке.
    /// </summary>
    public string? ShowMessage(NetEntity source, NetEntity target, string text)
    {
        if (string.IsNullOrEmpty(text))
            return Loc.GetString("directional-emote-empty-popup");

        var maxLength = _cfg.GetCVar(CCVars.ChatMaxEmoteLength);
        if (text.Length > maxLength)
            return Loc.GetString("directional-emote-length-popup", ("maxLength", maxLength));

        RaiseNetworkEvent(new SendDirectionalEmoteEvent(source, target, text));
        return null;
    }

    private void OnGetVerbs(EntityUid uid, DirectionalEmoteTargetComponent component, GetVerbsEvent<Verb> args)
    {
        if (args.Target == args.User ||
            !HasComp<DirectionalEmoteTargetComponent>(args.User))
            return;

        var source = GetNetEntity(args.User);
        var target = GetNetEntity(args.Target);

        args.Verbs.Add(new Verb
        {
            Act = () => _userInterfaceManager.GetUIController<DirectionalEmoteUIController>().ToggleWindow(source, target),
            Priority = 15,
            Text = Loc.GetString("directional-emote-verb-name"),
            Icon = new SpriteSpecifier.Texture(new ResPath("/Textures/Interface/emotes.svg.192dpi.png")),
            ClientExclusive = true,
        });
    }
}
