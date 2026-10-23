using System;
using Content.Server._LP.Holiday;
using NUnit.Framework;

namespace Content.Tests.Server._LP.Holiday;

[TestFixture]
[TestOf(typeof(MaslenitsaShouldCelebrate))]
public sealed class MaslenitsaShouldCelebrateTest
{
    [Test]
    [TestCase(2000, 4, 30)]
    [TestCase(2010, 4, 4)]
    [TestCase(2019, 4, 28)]
    [TestCase(2020, 4, 19)]
    [TestCase(2021, 5, 2)]
    [TestCase(2022, 4, 24)]
    [TestCase(2023, 4, 16)]
    [TestCase(2024, 5, 5)]
    [TestCase(2025, 4, 20)]
    [TestCase(2026, 4, 12)]
    [TestCase(2027, 5, 2)]
    [TestCase(2028, 4, 16)]
    [TestCase(2029, 4, 8)]
    [TestCase(2030, 4, 28)]
    public void OrthodoxEasterMatchesKnownDates(int year, int month, int day)
    {
        Assert.That(MaslenitsaShouldCelebrate.GetOrthodoxEaster(year), Is.EqualTo(new DateOnly(year, month, day)));
    }

    // В 2026 году Пасха 12 апреля, Масленица - неделя с 16 по 22 февраля.
    [Test]
    [TestCase(2026, 2, 15, false)]
    [TestCase(2026, 2, 16, true)]
    [TestCase(2026, 2, 19, true)]
    [TestCase(2026, 2, 22, true)]
    [TestCase(2026, 2, 23, false)]
    [TestCase(2026, 4, 12, false)]
    // Пасха 5 мая 2024: Масленица с 11 по 17 марта.
    [TestCase(2024, 3, 10, false)]
    [TestCase(2024, 3, 11, true)]
    [TestCase(2024, 3, 17, true)]
    [TestCase(2024, 3, 18, false)]
    public void MaslenitsaIsTheWeekBeforeTheGreatLent(int year, int month, int day, bool expected)
    {
        var celebrate = new MaslenitsaShouldCelebrate();

        // Время суток не должно влиять: последний день недели длится до полуночи.
        Assert.That(celebrate.ShouldCelebrate(new DateTime(year, month, day, 23, 59, 0), null!), Is.EqualTo(expected));
        Assert.That(celebrate.ShouldCelebrate(new DateTime(year, month, day, 0, 0, 0), null!), Is.EqualTo(expected));
    }
}
