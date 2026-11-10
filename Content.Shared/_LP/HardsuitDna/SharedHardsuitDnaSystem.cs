using Content.Shared.Administration.Logs;
using Content.Shared.Database;
using Content.Shared.Examine;
using Content.Shared.Forensics.Components;
using Content.Shared.Popups;
using Content.Shared.Verbs;

namespace Content.Shared._LP.HardsuitDna;

/// <summary>
/// Общая часть привязки скафандров к ДНК: осмотр и действия владельца (сброс привязки, блокировка).
/// Отсчёт и взрыв - на сервере.
/// </summary>
public abstract partial class SharedHardsuitDnaSystem : EntitySystem
{
    [Dependency] protected ISharedAdminLogManager AdminLog = default!;
    [Dependency] protected SharedPopupSystem Popup = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<HardsuitDnaComponent, ExaminedEvent>(OnExamined);
        SubscribeLocalEvent<HardsuitDnaComponent, GetVerbsEvent<AlternativeVerb>>(OnGetVerbs);
    }

    private void OnExamined(Entity<HardsuitDnaComponent> ent, ref ExaminedEvent args)
    {
        if (ent.Comp.Dna == null)
        {
            args.PushMarkup(Loc.GetString("hardsuit-dna-examine-unbound"));
            return;
        }

        var key = IsOwner(ent, args.Examiner) ? "hardsuit-dna-examine-bound-owner" : "hardsuit-dna-examine-bound";
        args.PushMarkup(Loc.GetString(key));
    }

    private void OnGetVerbs(Entity<HardsuitDnaComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract || !IsOwner(ent, args.User))
            return;

        var user = args.User;

        args.Verbs.Add(new AlternativeVerb
        {
            Text = Loc.GetString("hardsuit-dna-verb-reset"),
            Message = Loc.GetString("hardsuit-dna-verb-reset-message"),
            ConfirmationPopup = true,
            Impact = LogImpact.Medium,
            Priority = 1,
            Act = () => TryReset(ent.AsNullable(), user),
        });
    }

    /// <summary>
    /// Совпадает ли ДНК пользователя с ДНК, к которой привязан скафандр. Без ДНК у пользователя владельцем не считается.
    /// </summary>
    public bool IsOwner(Entity<HardsuitDnaComponent> ent, EntityUid user) => ent.Comp.Dna != null
                && TryComp<DnaComponent>(user, out var dna)
                && dna.DNA == ent.Comp.Dna;

    /// <summary>
    /// Сбрасывает привязку: скафандр снова не привязан и привяжется к следующему надевшему.
    /// </summary>
    public bool TryReset(Entity<HardsuitDnaComponent?> ent, EntityUid user)
    {
        if (!Resolve(ent, ref ent.Comp, false) || !IsOwner((ent, ent.Comp), user))
            return false;

        ent.Comp.Dna = null;
        Dirty(ent);

        Popup.PopupClient(Loc.GetString("hardsuit-dna-popup-reset"), ent, user);
        AdminLog.Add(LogType.Action, LogImpact.Medium,
            $"{ToPrettyString(user):user} reset the DNA binding of {ToPrettyString(ent):hardsuit}");
        return true;
    }
}
