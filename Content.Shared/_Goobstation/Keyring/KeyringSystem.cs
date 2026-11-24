using System.Linq;
using Content.Shared.Access.Systems;
using Content.Shared.DoAfter;
using Content.Shared.Doors;
using Content.Shared.Doors.Components;
using Content.Shared.Doors.Systems;
using Content.Shared.Interaction;
using Content.Shared.Popups;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Random;

namespace Content.Shared._Goobstation.Keyring;

public sealed partial class KeyringSystem : EntitySystem
{
    [Dependency] private SharedDoAfterSystem _doAfter = default!;
    [Dependency] private SharedPopupSystem _popupSystem = default!;
    [Dependency] private SharedDoorSystem _doorSystem = default!;
    [Dependency] private AccessReaderSystem _access = default!;
    [Dependency] private SharedAudioSystem _audioSystem = default!;
    [Dependency] private IRobustRandom _random = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<KeyringComponent, MapInitEvent>(OnInit);
        SubscribeLocalEvent<KeyringComponent, AfterInteractEvent>(OnInteractUsing);
        SubscribeLocalEvent<KeyringComponent, KeyringDoAfterEvent>(OnDoAfterEvent);
    }

    private void OnInit(Entity<KeyringComponent> keyring, ref MapInitEvent mapInitEvent)
    {
        if (keyring.Comp.PossibleAccesses.Count == 0)
            return;

        // LP edit start
        // Один список на все выборы: без повторов и без падения, если доступов меньше лимита.
        var possible = keyring.Comp.PossibleAccesses.ToList();
        var changed = false;
        for (var i = 0; i < keyring.Comp.MaxPossibleAccesses && possible.Count > 0; i++)
        {
            var pick = _random.PickAndTake(possible);
            changed |= keyring.Comp.Tags.Add(pick); // We don't use access comp for this because otherwise you can use it like an ID card to bump open doors :P
        }

        if (changed)
            Dirty(keyring);
        // LP edit end
    }
    private void OnInteractUsing(Entity<KeyringComponent> keyring, ref AfterInteractEvent args)
    {
        if (args.Handled
            || !HasComp<DoorComponent>(args.Target)
            || !args.CanReach)
            return;

        var doAfterArgs =
            new DoAfterArgs(EntityManager,
                args.User,
                keyring.Comp.UnlockAttemptDuration,
                new KeyringDoAfterEvent(),
                keyring,
                args.Target)
            {
                BlockDuplicate = true,
                BreakOnMove = true,
                NeedHand = true, // LP edit
                BreakOnHandChange = true,
                BreakOnDamage = true,
            };

        if (!_doAfter.TryStartDoAfter(doAfterArgs)) // LP edit
            return;

        var popup = Loc.GetString("keyring-start-unlock-popup");
        _popupSystem.PopupClient(popup, args.User, args.User);

        _audioSystem.PlayPredicted(keyring.Comp.UseSound, keyring, args.User);

        args.Handled = true;
    }

    private void OnDoAfterEvent(Entity<KeyringComponent> keyring, ref KeyringDoAfterEvent args)
    {
        if (args.Handled
            || args.Cancelled
            || args.Target is not { } target
            || !_access.GetMainAccessReader(target, out var accessReader))
            return;

        if (_access.AreAccessTagsAllowed(keyring.Comp.Tags, accessReader.Value)) // LP edit
        {
            // LP edit start
            // Ключ не открывает заваренную, заболченную, обесточенную или уже открытую дверь.
            if (!CanUnlock(target, args.User))
            {
                _popupSystem.PopupPredicted(Loc.GetString("keyring-unlock-blocked-popup"), args.User, args.User);
                args.Handled = true;
                return;
            }

            _doorSystem.StartOpening(target, user: args.User, predicted: true);
            // LP edit end

            var successPopup = Loc.GetString("keyring-finish-unlock-popup");
            _popupSystem.PopupPredicted(successPopup, args.User, args.User);

            args.Handled = true;

            return;
        }


        var failPopup = Loc.GetString("keyring-unlock-fail-popup");
        _popupSystem.PopupPredicted(failPopup, args.User, args.User);

        args.Handled = true;
    }

    // LP edit start
    private bool CanUnlock(EntityUid door, EntityUid user)
    {
        if (!TryComp<DoorComponent>(door, out var doorComp) || doorComp.State != DoorState.Closed)
            return false;

        var ev = new BeforeDoorOpenedEvent { User = user };
        RaiseLocalEvent(door, ev);
        return !ev.Cancelled;
    }
    // LP edit end
}
