using Content.Server.Holiday;
using Content.Shared.GameTicking;
using Robust.Shared.Prototypes;

namespace Content.Server._LP.Holiday;

/// <summary>
/// Единое место проверки, идёт ли праздник для маркеров: календарь плюс принудительно включённые командой.
/// </summary>
public sealed partial class HolidayEffectsSystem : EntitySystem
{
    [Dependency] private HolidaySystem _holiday = default!;
    [Dependency] private IPrototypeManager _prototype = default!;

    private readonly HashSet<string> _forced = new();

    public override void Initialize()
    {
        SubscribeLocalEvent<RoundRestartCleanupEvent>(OnRoundRestartCleanup);
    }

    private void OnRoundRestartCleanup(RoundRestartCleanupEvent ev)
    {
        _forced.Clear();
    }

    /// <summary>
    /// Идёт ли праздник. Если праздники выключены (holidays.enabled), всегда false, даже для принудительных.
    /// </summary>
    public bool IsActive(string holidayId)
    {
        if (!_holiday.enabled)
            return false;

        return _forced.Contains(holidayId) || _holiday.IsCurrentlyHoliday(holidayId);
    }

    /// <summary>
    /// Идёт ли хотя бы один из праздников.
    /// </summary>
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

    /// <summary>
    /// Принудительно включает праздник для маркеров до конца раунда. False, если такого праздника нет.
    /// </summary>
    public bool TryForce(string holidayId)
    {
        if (!_prototype.HasIndex<HolidayPrototype>(holidayId))
            return false;

        _forced.Add(holidayId);
        return true;
    }
}
