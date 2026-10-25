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

        if (ent.Comp.Locked)
            args.PushMarkup(Loc.GetString("hardsuit-dna-examine-locked"));
    }

    private void OnGetVerbs(Entity<HardsuitDnaComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract || !IsOwner(ent, args.User))
            return;

        var user = args.User;

        if (!ent.Comp.Locked)
        {
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

        args.Verbs.Add(new AlternativeVerb
        {
            Text = Loc.GetString(ent.Comp.Locked ? "hardsuit-dna-verb-unlock" : "hardsuit-dna-verb-lock"),
            Impact = LogImpact.Medium,
            Priority = 0,
            Act = () => TryToggleLock(ent.AsNullable(), user),
        });
    }

    /// <summary>
    /// Совпадает ли ДНК пользователя с ДНК, к которой привязан скафандр. Без ДНК у пользователя владельцем не считается.
    /// </summary>
    public bool IsOwner(Entity<HardsuitDnaComponent> ent, EntityUid user)
    {
        return ent.Comp.Dna != null
                && TryComp<DnaComponent>(user, out var dna)
                && dna.DNA == ent.Comp.Dna;
    }

    public bool CanReset(Entity<HardsuitDnaComponent> ent, EntityUid user, bool quiet = false)
    {
        if (!IsOwner(ent, user))
            return false;

        if (!ent.Comp.Locked)
            return true;

        if (!quiet)
            Popup.PopupClient(Loc.GetString("hardsuit-dna-popup-reset-locked"), ent, user);

        return false;
    }

    /// <summary>
    /// Сбрасывает привязку: скафандр снова не привязан и привяжется к следующему надевшему.
    /// </summary>
    public bool TryReset(Entity<HardsuitDnaComponent?> ent, EntityUid user)
    {
        if (!Resolve(ent, ref ent.Comp, false) || !CanReset((ent, ent.Comp), user))
            return false;

        ent.Comp.Dna = null;
        Dirty(ent);

        Popup.PopupClient(Loc.GetString("hardsuit-dna-popup-reset"), ent, user);
        AdminLog.Add(LogType.Action, LogImpact.Medium,
            $"{ToPrettyString(user):user} reset the DNA binding of {ToPrettyString(ent):hardsuit}");
        return true;
    }

    public bool TryToggleLock(Entity<HardsuitDnaComponent?> ent, EntityUid user)
    {
        if (!Resolve(ent, ref ent.Comp, false) || !IsOwner((ent, ent.Comp), user))
            return false;

        ent.Comp.Locked = !ent.Comp.Locked;
        Dirty(ent);

        Popup.PopupClient(Loc.GetString(ent.Comp.Locked ? "hardsuit-dna-popup-locked" : "hardsuit-dna-popup-unlocked"), ent, user);
        AdminLog.Add(LogType.Action, LogImpact.Medium,
            $"{ToPrettyString(user):user} {(ent.Comp.Locked ? "locked" : "unlocked")} the DNA binding of {ToPrettyString(ent):hardsuit}");
        return true;
    }
}
