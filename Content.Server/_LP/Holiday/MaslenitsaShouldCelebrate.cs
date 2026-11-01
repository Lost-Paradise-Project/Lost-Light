using Content.Server.Holiday;
using Content.Server.Holiday.Interfaces;
using JetBrains.Annotations;

namespace Content.Server._LP.Holiday;

[UsedImplicitly]
[DataDefinition]
public sealed partial class MaslenitsaShouldCelebrate : IHolidayShouldCelebrate
{
    private const int DaysBeforeEasterStart = 55;
    private const int DaysBeforeEasterEnd = 49;

    public bool ShouldCelebrate(DateTime date, HolidayPrototype holiday)
    {
        var easter = GetOrthodoxEaster(date.Year);
        var day = DateOnly.FromDateTime(date);

        return day >= easter.AddDays(-DaysBeforeEasterStart) && day <= easter.AddDays(-DaysBeforeEasterEnd);
    }

    public static DateOnly GetOrthodoxEaster(int year)
    {
        var a = year % 4;
        var b = year % 7;
        var c = year % 19;
        var d = ((19 * c) + 15) % 30;
        var e = ((2 * a) + (4 * b) - d + 34) % 7;

        var month = (d + e + 114) / 31;
        var day = ((d + e + 114) % 31) + 1;

        // Разница юлианского и григорианского календарей: 13 дней для 1900-2099, дальше растёт.
        var shift = (year / 100) - (year / 400) - 2;

        return new DateOnly(year, month, day).AddDays(shift);
    }
}
