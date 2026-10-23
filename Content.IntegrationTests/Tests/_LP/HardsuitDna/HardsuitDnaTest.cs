using Content.IntegrationTests.Fixtures;
using Content.Server._LP.HardsuitDna;
using Content.Shared._LP.HardsuitDna;
using Content.Shared.Access.Components;
using Content.Shared.Forensics.Components;
using Content.Shared.Inventory;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;

namespace Content.IntegrationTests.Tests._LP.HardsuitDna;

public sealed class HardsuitDnaTest : GameTest
{
    private const string Slot = "outerClothing";

    private static readonly EntProtoId JuggernautLocked = "ClothingOuterHardsuitJuggernautLocked";

    // Нестанционные скафандры и потомки, которые получают привязку от родителей
    private static readonly string[] Bound =
    [
        "ClothingOuterHardsuitSyndie",
        "ClothingOuterHardsuitSyndieMouseOps",
        "ClothingOuterHardsuitJuggernaut",
        "ClothingOuterHardsuitJuggernautLocked",
        "ClothingOuterHardsuitDeathsquad",
        "ClothingOuterHardsuitERTLeader",
        "ClothingOuterHardsuitERTSecurity",
        "ClothingOuterHardsuitNTSF",
        "ClothingOuterHardsuitTSFPhantom",
        "ClothingOuterHardsuitTSFMARSOC",
        "ClothingOuterHardsuitThanatos",
    ];

    // Спорные скафандры, унаследовавшие компонент от разрешённых родителей: привязка выключена
    private static readonly string[] Disabled =
    [
        "ClothingOuterHardsuitGreenshield",
        "ClothingOuterHardsuitNTNCConsortium",
        "ClothingOuterHardsuitNTNCConsortiumMedic",
    ];

    // Станционные, шуточные и спорные скафандры без привязки
    private static readonly string[] Unbound =
    [
        "ClothingOuterHardsuitEngineering",
        "ClothingOuterHardsuitAtmos",
        "ClothingOuterHardsuitSecurity",
        "ClothingOuterHardsuitMedical",
        "ClothingOuterHardsuitCap",
        "ClothingOuterHardsuitBlueshield",
        "ClothingOuterHardsuitClown",
        "ClothingOuterHardsuitWizard",
        "ClothingOuterHardsuitPirateCap",
        "ClothingOuterHardsuitSpaceHazard",
        "ClothingOuterHardsuitEVA",
    ];

    [Test]
    public async Task PrototypesTest()
    {
        await Server.WaitAssertion(() =>
        {
            var factory = SEntMan.ComponentFactory;

            foreach (var id in Bound)
            {
                var proto = SProtoMan.Index<EntityPrototype>(id);
                Assert.That(proto.TryComp<HardsuitDnaComponent>(out var comp, factory), $"{id} без HardsuitDna");
                Assert.That(comp!.Enabled, $"{id}: привязка выключена");
            }

            foreach (var id in Disabled)
            {
                var proto = SProtoMan.Index<EntityPrototype>(id);
                Assert.That(proto.TryComp<HardsuitDnaComponent>(out var comp, factory), $"{id} без HardsuitDna");
                Assert.That(comp!.Enabled, Is.False, $"{id}: привязка должна быть выключена");
            }

            foreach (var id in Unbound)
            {
                var proto = SProtoMan.Index<EntityPrototype>(id);
                Assert.That(proto.HasComp<HardsuitDnaComponent>(factory), Is.False, $"{id} не должен иметь HardsuitDna");
            }

            // Доступ заменён привязкой к ДНК
            var locked = SProtoMan.Index(JuggernautLocked);
            Assert.That(locked.HasComp<AccessReaderComponent>(factory), Is.False);
        });
    }

    [Test]
    public async Task BindResetAndCountdownTest()
    {
        var map = await Pair.CreateTestMap();

        EntityUid owner = default, other = default, suit = default;
        await Server.WaitPost(() =>
        {
            owner = SSpawnAtPosition("MobHuman", map.GridCoords);
            other = SSpawnAtPosition("MobHuman", map.GridCoords);
            suit = SSpawnAtPosition("ClothingOuterHardsuitJuggernaut", map.GridCoords);
        });
        await RunTicksSync(5);

        await Server.WaitAssertion(() =>
        {
            var inventory = SEntMan.System<InventorySystem>();
            var dnaSystem = SEntMan.System<HardsuitDnaSystem>();
            var ownerDna = SEntMan.GetComponent<DnaComponent>(owner).DNA;
            var suitComp = SEntMan.GetComponent<HardsuitDnaComponent>(suit);

            // Первый надевший становится владельцем
            Assert.That(suitComp.Dna, Is.Null);
            Assert.That(inventory.TryEquip(owner, suit, Slot, force: true));
            Assert.That(suitComp.Dna, Is.EqualTo(ownerDna));
            Assert.That(SEntMan.HasComponent<HardsuitDnaCountdownComponent>(suit), Is.False);

            // Блокировка запрещает сброс; чужой ничего сделать не может
            Assert.That(dnaSystem.TryToggleLock(suit, other), Is.False);
            Assert.That(dnaSystem.TryToggleLock(suit, owner));
            Assert.That(dnaSystem.TryReset(suit, owner), Is.False);
            Assert.That(dnaSystem.TryToggleLock(suit, owner));
            Assert.That(suitComp.Locked, Is.False);

            // Чужой надевает: идёт отсчёт, снять можно сразу несмотря на UnequipDelay скафандра
            Assert.That(inventory.TryUnequip(owner, Slot, force: true));
            Assert.That(inventory.TryEquip(other, suit, Slot, force: true));
            Assert.That(SEntMan.HasComponent<HardsuitDnaCountdownComponent>(suit));
            Assert.That(inventory.TryUnequip(other, Slot, checkDoafter: true), "UnequipDelay не обнулён на время отсчёта");
            Assert.That(SEntMan.HasComponent<HardsuitDnaCountdownComponent>(suit), Is.False, "отсчёт не отменён снятием");
            Assert.That(suitComp.Dna, Is.EqualTo(ownerDna));
        });

        // Снятый вовремя скафандр ничего не взорвал
        await RunSeconds(6);
        Assert.That(SEntMan.Deleted(other), Is.False);
        Assert.That(SEntMan.Deleted(suit), Is.False);

        await Server.WaitAssertion(() =>
        {
            var inventory = SEntMan.System<InventorySystem>();
            var dnaSystem = SEntMan.System<HardsuitDnaSystem>();
            var otherDna = SEntMan.GetComponent<DnaComponent>(other).DNA;
            var suitComp = SEntMan.GetComponent<HardsuitDnaComponent>(suit);

            // Владелец сбрасывает привязку, напарник привязывает скафандр к себе
            Assert.That(dnaSystem.TryReset(suit, other), Is.False);
            Assert.That(dnaSystem.TryReset(suit, owner));
            Assert.That(suitComp.Dna, Is.Null);
            Assert.That(inventory.TryEquip(other, suit, Slot, force: true));
            Assert.That(suitComp.Dna, Is.EqualTo(otherDna));
            Assert.That(SEntMan.HasComponent<HardsuitDnaCountdownComponent>(suit), Is.False);

            // Теперь чужой уже owner: если не снять, скафандр взрывается, носитель погибает
            Assert.That(inventory.TryUnequip(other, Slot, force: true));
            Assert.That(inventory.TryEquip(owner, suit, Slot, force: true));
            Assert.That(SEntMan.HasComponent<HardsuitDnaCountdownComponent>(suit));
        });

        await RunSeconds(6);
        Assert.That(SEntMan.Deleted(owner), "носитель должен быть загиблен");
        Assert.That(SEntMan.Deleted(suit), "скафандр должен быть удалён");
    }
}
