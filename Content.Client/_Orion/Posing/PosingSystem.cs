using Content.Shared._Orion.Posing;
using Content.Shared.Input;
using Robust.Client.GameObjects;
using Robust.Client.Input;
using Robust.Client.Player;

namespace Content.Client._Orion.Posing;

public sealed partial class PosingSystem : SharedPosingSystem
{
    [Dependency] private IInputManager _input = default!;
    [Dependency] private IPlayerManager _playerManager = default!;
    [Dependency] private SpriteSystem _sprite = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PosingComponent, AfterAutoHandleStateEvent>(OnAfterHandleState);

        var posing = _input.Contexts.New("posing", "common");
        posing.AddFunction(ContentKeyFunctions.TogglePosing);
        posing.AddFunction(ContentKeyFunctions.PosingOffsetUp);
        posing.AddFunction(ContentKeyFunctions.PosingOffsetDown);
        posing.AddFunction(ContentKeyFunctions.PosingOffsetLeft);
        posing.AddFunction(ContentKeyFunctions.PosingOffsetRight);
        posing.AddFunction(ContentKeyFunctions.PosingRotatePositive);
        posing.AddFunction(ContentKeyFunctions.PosingRotateNegative);
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _input.Contexts.Remove("posing");
    }

    private void OnAfterHandleState(EntityUid uid, PosingComponent component, ref AfterAutoHandleStateEvent args)
    {
        if (_playerManager.LocalEntity == uid)
        {
            UpdateInputContext(component); // LP edit
            return;
        }

        if (component.Posing)
            return;

        _sprite.SetOffset(uid, component.DefaultOffset);
        _sprite.SetRotation(uid, Angle.FromDegrees(component.DefaultAngle));
    }

    protected override void ClientTogglePosing(EntityUid uid, PosingComponent posing)
    {
        base.ClientTogglePosing(uid, posing);

        // LP edit start
        if (_playerManager.LocalEntity == uid)
            UpdateInputContext(posing);
        // LP edit end
        _sprite.SetOffset(uid, posing.DefaultOffset);
        _sprite.SetRotation(uid, Angle.FromDegrees(posing.DefaultAngle));
    }

    // LP edit start
    private void UpdateInputContext(PosingComponent posing)
    {
        var active = _input.Contexts.ActiveContext.Name;
        if (posing.Posing && active != "posing")
            _input.Contexts.SetActiveContext("posing");
        else if (!posing.Posing && active == "posing")
            _input.Contexts.SetActiveContext(posing.DefaultInputContext);
    }
    // LP edit end

    public override void FrameUpdate(float frameTime)
    {
        base.FrameUpdate(frameTime);

        var query = EntityQueryEnumerator<PosingComponent>();
        while (query.MoveNext(out var uid, out var posing))
        {
            if (!posing.Posing)
                continue;

            _sprite.SetOffset(uid, posing.DefaultOffset + posing.CurrentOffset);
            _sprite.SetRotation(uid, posing.CurrentAngle);
        }
    }
}
