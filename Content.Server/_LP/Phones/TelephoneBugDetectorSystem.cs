using Content.Shared._LP.Phones;
using Content.Shared.Beeper.Systems;
using Content.Shared.Item.ItemToggle;
using Robust.Shared.Map;

namespace Content.Server._LP.Phones;

/// <summary>
/// Детектор жучков: пока включён, ищет ближайший телефон с жучком в радиусе и пищит тем чаще, чем он ближе.
/// Телефоны с жучками есть только на сервере, поэтому поиск не в общем коде.
/// </summary>
public sealed partial class TelephoneBugDetectorSystem : EntitySystem
{
    private const float UpdateInterval = 1f;

    [Dependency] private BeeperSystem _beeper = default!;
    [Dependency] private ItemToggleSystem _toggle = default!;
    [Dependency] private SharedTransformSystem _transform = default!;

    private float _accumulator;

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        _accumulator += frameTime;
        if (_accumulator < UpdateInterval)
            return;

        _accumulator -= UpdateInterval;

        var detectors = EntityQueryEnumerator<TelephoneBugDetectorComponent>();
        while (detectors.MoveNext(out var uid, out var detector))
        {
            if (!_toggle.IsActivated(uid) || FindNearest(uid, detector.Range) is not { } distance)
            {
                _beeper.SetMute(uid, true);
                continue;
            }

            _beeper.SetMute(uid, false);
            _beeper.SetIntervalScaling(uid, distance / detector.Range);
        }
    }

    private float? FindNearest(EntityUid detector, float range)
    {
        var origin = _transform.GetMapCoordinates(detector);
        if (origin.MapId == MapId.Nullspace)
            return null;

        float? nearest = null;

        var phones = EntityQueryEnumerator<BuggedPhoneComponent, TransformComponent>();
        while (phones.MoveNext(out _, out _, out var xform))
        {
            var coords = _transform.GetMapCoordinates(xform);
            if (coords.MapId != origin.MapId)
                continue;

            var distance = (coords.Position - origin.Position).Length();
            if (distance <= range && (nearest == null || distance < nearest))
                nearest = distance;
        }

        return nearest;
    }
}
