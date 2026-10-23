#nullable enable
using System.Linq;
using Content.IntegrationTests.Tests.Interaction;
using Content.Server._LP.Holiday;
using Content.Server.Holiday;
using Content.Shared._LP.Holiday;
using Content.Shared.CCVar;
using Robust.Shared.Configuration;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;

namespace Content.IntegrationTests.Tests._LP.Holiday;

[TestFixture]
public sealed class HolidayEffectsTest : InteractionTest
{
    private async Task SetHolidaysEnabled(bool enabled)
    {
        await Server.WaitPost(() =>
        {
            Server.ResolveDependency<IConfigurationManager>().SetCVar(CCVars.HolidaysEnabled, enabled);
        });
    }

    private async Task Force(string holiday)
    {
        await Server.WaitPost(() => Assert.That(SEntMan.System<HolidayEffectsSystem>().TryForce(holiday)));
    }

    private bool IsActive(string holiday)
    {
        return SEntMan.System<HolidayEffectsSystem>().IsActive(holiday);
    }

    [Test]
    public async Task MarkerSpawnsOnlyDuringHoliday()
    {
        await SetHolidaysEnabled(true);
        var marker = SEntMan.GetEntity(await SpawnTarget("LPHolidayMarkerCustom"));

        await Server.WaitPost(() =>
        {
            var markerComp = SEntMan.GetComponent<HolidaySpawnerMarkerComponent>(marker);
            markerComp.Holiday = "Halloween";
            markerComp.Spawn = "CarvedPumpkin";
            markerComp.Chance = 1f;
        });

        var markers = SEntMan.System<HolidaySpawnerMarkerSystem>();
        var comp = SEntMan.GetComponent<HolidaySpawnerMarkerComponent>(marker);

        if (!IsActive("Halloween"))
        {
            await Server.WaitPost(() => markers.SpawnAll());
            Assert.That(comp.Spawned, Is.Null, "Маркер сработал вне праздника.");
        }

        await Force("Halloween");
        await Server.WaitPost(() => markers.SpawnAll());
        Assert.That(comp.Spawned, Is.Not.Null, "Маркер не создал сущность в праздник.");
        var first = comp.Spawned!.Value;
        Assert.That(SEntMan.HasComponent<HolidayEffectComponent>(first));

        // Повторный проход не создаёт дубль, пока сущность жива.
        await Server.WaitPost(() => markers.SpawnAll());
        Assert.That(comp.Spawned, Is.EqualTo(first));

        // Маркер остаётся на месте и после удаления сущности создаёт её заново.
        await Server.WaitPost(() => SEntMan.DeleteEntity(first));
        await Server.WaitPost(() => markers.SpawnAll());
        Assert.That(comp.Spawned, Is.Not.EqualTo(first));
        Assert.That(SEntMan.EntityExists(comp.Spawned), Is.True);
    }

    [Test]
    public async Task MarkerDoesNothingWhenHolidaysDisabled()
    {
        await SetHolidaysEnabled(false);
        var marker = SEntMan.GetEntity(await SpawnTarget("LPHolidayMarkerCustom"));

        await Server.WaitPost(() =>
        {
            var comp = SEntMan.GetComponent<HolidaySpawnerMarkerComponent>(marker);
            comp.Holiday = "Halloween";
            comp.Spawn = "CarvedPumpkin";
            comp.Chance = 1f;
            SEntMan.System<HolidayEffectsSystem>().TryForce("Halloween");
            SEntMan.System<HolidaySpawnerMarkerSystem>().SpawnAll();
            Assert.That(comp.Spawned, Is.Null, "Маркер сработал при выключенных праздниках.");
        });
    }

    [Test]
    public void PrototypesAreConsistent()
    {
        var holidays = ProtoMan.EnumeratePrototypes<HolidayPrototype>().Select(h => h.ID).ToHashSet();
        var factory = Server.ResolveDependency<IComponentFactory>();

        Assert.Multiple(() =>
        {
            foreach (var proto in ProtoMan.EnumeratePrototypes<EntityPrototype>())
            {
                if (proto.Abstract)
                    continue;

                if (!proto.TryComp<HolidaySpawnerMarkerComponent>(out var marker, factory) || proto.ID == "LPHolidayMarkerCustom")
                    continue;

                Assert.That(holidays, Does.Contain(marker.Holiday), $"{proto.ID}: нет праздника {marker.Holiday}");
                foreach (var extra in marker.ExtraHolidays)
                {
                    Assert.That(holidays, Does.Contain(extra), $"{proto.ID}: нет праздника {extra}");
                }

                Assert.That(marker.Spawn is { } spawn && ProtoMan.HasIndex<EntityPrototype>(spawn), $"{proto.ID}: нет прототипа {marker.Spawn}");
                Assert.That(marker.Chance, Is.InRange(0f, 1f), $"{proto.ID}: шанс вне 0..1");
            }
        });
    }
}
