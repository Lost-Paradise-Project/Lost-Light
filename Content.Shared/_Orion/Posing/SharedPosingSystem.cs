using System.Numerics;
using Content.Shared.ActionBlocker;
using Content.Shared.Damage.Components;
using Content.Shared.Input;
using Content.Shared.Mobs;
using Content.Shared.Movement.Events;
using Content.Shared.Standing;
using Content.Shared.Stunnable;
using Robust.Shared.Input.Binding;
using Robust.Shared.Player; // LP edit

namespace Content.Shared._Orion.Posing;

public abstract partial class SharedPosingSystem : EntitySystem
{
    [Dependency] private StandingStateSystem _standing = default!;
    [Dependency] private ActionBlockerSystem _actionBlocker = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PosingComponent, UpdateCanMoveEvent>(OnUpdateCanMove);
        SubscribeLocalEvent<PosingComponent, DownedEvent>(OnDowned);
        SubscribeLocalEvent<PosingComponent, MobStateChangedEvent>(OnMobStateChanged);

        CommandBinds.Builder
            .Bind(ContentKeyFunctions.TogglePosing,
                InputCmdHandler.FromDelegate(session =>
                    {
                        if (session?.AttachedEntity is { } userUid && CanTogglePosing(userUid))
                            TogglePosing(userUid);
                    },
                    handle: false))
            // LP edit start
            .Bind(ContentKeyFunctions.PosingOffsetRight, HeldHandler(new(1f, 0f), 0f))
            .Bind(ContentKeyFunctions.PosingOffsetLeft, HeldHandler(new(-1f, 0f), 0f))
            .Bind(ContentKeyFunctions.PosingOffsetUp, HeldHandler(new(0f, 1f), 0f))
            .Bind(ContentKeyFunctions.PosingOffsetDown, HeldHandler(new(0f, -1f), 0f))
            .Bind(ContentKeyFunctions.PosingRotatePositive, HeldHandler(Vector2.Zero, -1f))
            .Bind(ContentKeyFunctions.PosingRotateNegative, HeldHandler(Vector2.Zero, 1f))
            // LP edit end
            .Register<SharedPosingSystem>();
    }

    public override void Shutdown()
    {
        base.Shutdown();
        CommandBinds.Unregister<SharedPosingSystem>();
    }

    // LP edit start
    private InputCmdHandler HeldHandler(Vector2 offset, float angle)
    {
        return InputCmdHandler.FromDelegate(
            enabled: session => AdjustHeld(session, offset, angle),
            disabled: session => AdjustHeld(session, -offset, -angle),
            handle: false);
    }

    private void AdjustHeld(ICommonSession? session, Vector2 offset, float angle)
    {
        if (session?.AttachedEntity is not { } userUid || !TryComp<PosingComponent>(userUid, out var posing))
            return;

        // Ограничиваем, чтобы повторные Down без Up не разгоняли позу
        posing.HeldOffset = Vector2.Clamp(posing.HeldOffset + offset, -Vector2.One, Vector2.One);
        posing.HeldAngle = Math.Clamp(posing.HeldAngle + angle, -1f, 1f);
        Dirty(userUid, posing);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<PosingComponent>();
        while (query.MoveNext(out var uid, out var posing))
        {
            if (!posing.Posing)
                continue;

            if (posing.HeldOffset != Vector2.Zero)
                TryAdjustPosingOffset(uid, posing.HeldOffset * posing.OffsetSpeed * frameTime, posing);
            if (posing.HeldAngle != 0f)
                TryAdjustPosingAngle(uid, posing.HeldAngle * posing.AngleSpeed * frameTime, posing);
        }
    }
    // LP edit end

    private static void OnUpdateCanMove(EntityUid uid, PosingComponent component, UpdateCanMoveEvent args)
    {
        if (component.Posing)
            args.Cancel();
    }

    private void OnDowned(EntityUid uid, PosingComponent component, EntityEventArgs args)
    {
        if (component.Posing)
            TogglePosing(uid, component);
    }

    private void OnMobStateChanged(EntityUid uid, PosingComponent component, ref MobStateChangedEvent args)
    {
        if (component.Posing)
            TogglePosing(uid, component);
    }

    private void TogglePosing(EntityUid uid, PosingComponent? posingComp = null)
    {
        if (!Resolve(uid, ref posingComp, false))
            return;

        posingComp.Posing = !posingComp.Posing;
        _actionBlocker.UpdateCanMove(uid);

        posingComp.CurrentAngle = Angle.Zero;
        posingComp.CurrentOffset = Vector2.Zero;
        // LP edit start
        posingComp.HeldOffset = Vector2.Zero;
        posingComp.HeldAngle = 0f;
        // LP edit end

        ClientTogglePosing(uid, posingComp);
        Dirty(uid, posingComp);
    }

    private void TryAdjustPosingOffset(EntityUid uid, Vector2 offset, PosingComponent? posingComp = null)
    {
        if (!Resolve(uid, ref posingComp, false) || !posingComp.Posing)
            return;

        var previousOffset = posingComp.CurrentOffset;

        posingComp.CurrentOffset += offset;
        posingComp.CurrentOffset = Vector2.Clamp(posingComp.CurrentOffset, -posingComp.OffsetLimits, posingComp.OffsetLimits);

        if (posingComp.CurrentOffset.Equals(previousOffset))
            return;

        Dirty(uid, posingComp);
    }

    private void TryAdjustPosingAngle(EntityUid uid, float angle, PosingComponent? posingComp = null)
    {
        if (!Resolve(uid, ref posingComp, false) || !posingComp.Posing)
            return;

        var previousAngle = posingComp.CurrentAngle;

        var newAngle = posingComp.CurrentAngle.Degrees + angle;
        posingComp.CurrentAngle = Angle.FromDegrees(Math.Clamp(newAngle, -posingComp.AngleLimits, posingComp.AngleLimits));

        if (posingComp.CurrentAngle.Equals(previousAngle))
            return;

        Dirty(uid, posingComp);
    }

    protected virtual void ClientTogglePosing(EntityUid uid, PosingComponent posing)
    {
    }

    private bool CanTogglePosing(EntityUid uid)
    {
        if (!_actionBlocker.CanConsciouslyPerformAction(uid))
            return false;

        if (TryComp<StaminaComponent>(uid, out var stamina) && stamina.Critical)
            return false;

        if (HasComp<StunnedComponent>(uid))
            return false;

        if (_standing.IsDown(uid))
            return false;

        return true;
    }
}
