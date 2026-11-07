using Content.Server.Holiday;
using Content.Shared.GameTicking;
using Robust.Shared.Prototypes;

namespace Content.Server._LP.Holiday;

public sealed partial class HolidayEffectsSystem : EntitySystem
{
    [Dependency] private HolidaySystem _holiday = default!;
    [Dependency] private IPrototypeManager _prototype = default!;

    private readonly HashSet<string> _forced = new();

    public override void Initialize() => SubscribeLocalEvent<RoundRestartCleanupEvent>(OnRoundRestartCleanup);

    private void OnRoundRestartCleanup(RoundRestartCleanupEvent ev) => _forced.Clear();

    public bool HolidaysEnabled => _holiday.enabled;

    public bool IsActive(string holidayId)
    {
        if (!_holiday.enabled)
            return false;

        return _forced.Contains(holidayId) || _holiday.IsCurrentlyHoliday(holidayId);
    }

    public bool IsAnyActive(string holidayId, IEnumerable<string> extraHolidays)
    {
        if (IsActive(holidayId))
            return true;

        foreach (var extra in extraHolidays)
        {
            if (IsActive(extra))
                return true;
        }

        return false;
    }

    public bool TryForce(string holidayId)
    {
        if (!_prototype.HasIndex<HolidayPrototype>(holidayId))
            return false;

        _forced.Add(holidayId);
        return true;
    }
}
