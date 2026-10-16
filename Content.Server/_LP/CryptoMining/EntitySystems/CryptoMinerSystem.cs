using Content.Server._LP.CryptoMining.Components;
using Content.Server.Atmos.EntitySystems;
using Content.Server.Cargo.Systems;
using Content.Server.Construction;
using Content.Server.Construction.Components;
using Content.Server.Station.Systems;
using Content.Shared._LP.CryptoMining.Components;
using Content.Shared._LP.CryptoMining.EntitySystems;
using Content.Shared._Moffstation.BladeServer;
using Content.Shared.Cargo.Components;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Damage.Systems;
using Content.Shared.Emag.Systems;
using Content.Shared.Power.EntitySystems;
using Robust.Shared.Containers;
using Robust.Shared.Timing;

namespace Content.Server._LP.CryptoMining.EntitySystems;

/// <summary>
/// Раз в секунду считает нагрев, урон и доход майнеров и периодически переводит доход в бюджет станции.
/// </summary>
public sealed partial class CryptoMinerSystem : SharedCryptoMinerSystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private AtmosphereSystem _atmos = default!;
    [Dependency] private CargoSystem _cargo = default!;
    [Dependency] private DamageableSystem _damageable = default!;
    [Dependency] private EmagSystem _emag = default!;
    [Dependency] private ItemSlotsSystem _itemSlots = default!;
    [Dependency] private SharedContainerSystem _container = default!;
    [Dependency] private SharedPowerReceiverSystem _power = default!;
    [Dependency] private StationSystem _station = default!;

    private static readonly TimeSpan UpdateInterval = TimeSpan.FromSeconds(1);

    private TimeSpan _nextUpdate;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CryptoMinerComponent, ConstructionChangeEntityEvent>(OnChangeEntity);
    }

    // Разборка в раму: чип выпадает, урон уходит на плату.
    private void OnChangeEntity(EntityUid uid, CryptoMinerComponent component, ConstructionChangeEntityEvent args)
    {
        if (args.Old != uid)
            return;

        _itemSlots.TryEject(uid, component.ChipSlot, null, out _);

        if (_damageable.GetTotalDamage(uid) <= 0 || TryGetBoard(args.New) is not { } board)
            return;

        EnsureComp<CryptoMinerBoardDamageComponent>(board).Damage = _damageable.GetAllDamage(uid);
    }

    // Сборка из рамы: возвращаем урон с платы.
    protected override void AfterMapInit(Entity<CryptoMinerComponent> ent)
    {
        if (TryGetBoard(ent) is not { } board
            || !TryComp<CryptoMinerBoardDamageComponent>(board, out var stored))
            return;

        _damageable.TryChangeDamage(ent.Owner, stored.Damage, ignoreResistances: true, interruptsDoAfters: false);
        RemComp(board, stored);
    }

    private EntityUid? TryGetBoard(EntityUid uid)
    {
        if (!_container.TryGetContainer(uid, MachineFrameComponent.BoardContainerName, out var container)
            || container.ContainedEntities.Count == 0)
            return null;

        return container.ContainedEntities[0];
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        if (_timing.CurTime < _nextUpdate)
            return;

        _nextUpdate = _timing.CurTime + UpdateInterval;
        var dt = (float)UpdateInterval.TotalSeconds;

        var query = EntityQueryEnumerator<CryptoMinerComponent>();
        while (query.MoveNext(out var uid, out var miner))
        {
            UpdateMiner((uid, miner), dt);
        }
    }

    private void UpdateMiner(Entity<CryptoMinerComponent> ent, float dt)
    {
        if (!_container.TryGetContainingContainer(ent.Owner, out var container)
            || !HasComp<BladeServerRackComponent>(container.Owner))
        {
            SetState(ent, CryptoMinerStatus.NotInRack, 0, 0);
            return;
        }

        var rack = container.Owner;

        // Выключенный слот стойки отключает блейд от сети.
        if (!_power.IsPowered(ent.Owner) || !_power.IsPowered(rack))
        {
            SetState(ent, CryptoMinerStatus.NoPower, 0, 0);
            return;
        }

        var emagged = _emag.CheckFlag(ent, EmagType.Interaction);

        // Газ тайла стойки. У почти пустой смеси AddHeat разогнал бы температуру до бесконечности.
        var mixture = _atmos.GetContainingMixture(rack, ignoreExposed: true, excite: true);
        if (mixture == null || mixture.Immutable || mixture.Pressure < ent.Comp.MinPressure)
        {
            SetState(ent, CryptoMinerStatus.NoCooling, 0, 0);
            return;
        }

        var temperature = mixture.Temperature;
        var efficiency = GetEfficiency(ent.Comp, temperature);

        if (temperature > ent.Comp.DamageTemperature)
            _damageable.TryChangeDamage(ent.Owner, ent.Comp.OverheatDamage * dt, interruptsDoAfters: false);

        _atmos.AddHeat(mixture, GetHeatPower(ent, emagged) * dt);

        if (efficiency <= 0f)
        {
            SetState(ent, CryptoMinerStatus.Overheated, 0, 0);
            return;
        }

        if (_station.GetOwningStation(rack) is not { } station
            || !TryComp<StationBankAccountComponent>(station, out var bank))
        {
            SetState(ent, CryptoMinerStatus.NoStation, 0, 0);
            return;
        }

        var income = ent.Comp.BaseIncomePerMinute * efficiency;
        if (emagged)
            income *= ent.Comp.EmaggedIncomeMultiplier;

        if (GetChip(ent) is { } chip)
            income *= chip.IncomeMultiplier;

        ent.Comp.PendingIncome += income * dt / 60f;
        SetState(ent, CryptoMinerStatus.Working, (int)MathF.Round(efficiency * 100f), (int)MathF.Round(income));

        if (_timing.CurTime < ent.Comp.NextPayout)
            return;

        ent.Comp.NextPayout = _timing.CurTime + ent.Comp.PayoutInterval;
        Payout(ent, (station, bank));
    }

    private void Payout(Entity<CryptoMinerComponent> ent, Entity<StationBankAccountComponent> station)
    {
        var amount = (int)MathF.Floor(ent.Comp.PendingIncome);
        if (amount <= 0)
            return;

        ent.Comp.PendingIncome -= amount;

        if (ent.Comp.Account is { } account)
            _cargo.UpdateBankAccount(station.AsNullable(), amount, account);
        else
            _cargo.UpdateBankAccount(station.AsNullable(), amount, station.Comp.RevenueDistribution);
    }

    private static float GetEfficiency(CryptoMinerComponent miner, float temperature)
    {
        if (temperature <= miner.OptimalTemperature)
            return 1f;

        if (temperature >= miner.ShutdownTemperature)
            return 0f;

        return 1f - (temperature - miner.OptimalTemperature) / (miner.ShutdownTemperature - miner.OptimalTemperature);
    }
}
