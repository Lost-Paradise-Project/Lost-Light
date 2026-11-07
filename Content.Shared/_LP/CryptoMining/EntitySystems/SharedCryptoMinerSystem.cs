using Content.Shared._LP.CryptoMining.Components;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Emag.Systems;
using Content.Shared.Examine;
using Content.Shared.Power.EntitySystems;
using Robust.Shared.Containers;

namespace Content.Shared._LP.CryptoMining.EntitySystems;

/// <summary>
/// Нагрузка на ЛКП, осмотр, емаг и чипы. Добыча, нагрев и выплаты - на сервере.
/// </summary>
public abstract partial class SharedCryptoMinerSystem : EntitySystem
{
    [Dependency] private EmagSystem _emag = default!;
    [Dependency] private ItemSlotsSystem _itemSlots = default!;
    [Dependency] private SharedPowerReceiverSystem _powerReceiver = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CryptoMinerComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<CryptoMinerComponent, ExaminedEvent>(OnExamined);
        SubscribeLocalEvent<CryptoMinerComponent, GotEmaggedEvent>(OnEmagged);
        SubscribeLocalEvent<CryptoMinerComponent, EntInsertedIntoContainerMessage>(OnChipChanged);
        SubscribeLocalEvent<CryptoMinerComponent, EntRemovedFromContainerMessage>(OnChipChanged);
    }

    private void OnMapInit(Entity<CryptoMinerComponent> ent, ref MapInitEvent args)
    {
        UpdatePowerLoad(ent);
        AfterMapInit(ent);
    }

    protected virtual void AfterMapInit(Entity<CryptoMinerComponent> ent)
    {
    }

    private void OnChipChanged(Entity<CryptoMinerComponent> ent, ref EntInsertedIntoContainerMessage args)
    {
        if (args.Container.ID == ent.Comp.ChipSlot)
            UpdatePowerLoad(ent);
    }

    private void OnChipChanged(Entity<CryptoMinerComponent> ent, ref EntRemovedFromContainerMessage args)
    {
        if (args.Container.ID == ent.Comp.ChipSlot)
            UpdatePowerLoad(ent);
    }

    private void OnExamined(Entity<CryptoMinerComponent> ent, ref ExaminedEvent args)
    {
        if (!args.IsInDetailsRange)
            return;

        // Емаг в осмотре намеренно не виден.
        var message = ent.Comp.Status switch
        {
            CryptoMinerStatus.Working => Loc.GetString("crypto-miner-examine-working",
                ("efficiency", ent.Comp.Efficiency),
                ("income", ent.Comp.IncomePerMinute)),
            CryptoMinerStatus.Overheated => Loc.GetString("crypto-miner-examine-overheated"),
            CryptoMinerStatus.NoCooling => Loc.GetString("crypto-miner-examine-no-cooling"),
            CryptoMinerStatus.NoStation => Loc.GetString("crypto-miner-examine-no-station"),
            CryptoMinerStatus.NoPower => Loc.GetString("crypto-miner-examine-no-power"),
            _ => Loc.GetString("crypto-miner-examine-not-in-rack"),
        };

        args.PushMarkup(message);

        if (_itemSlots.GetItemOrNull(ent, ent.Comp.ChipSlot) is { } chip)
            args.PushMarkup(Loc.GetString("crypto-miner-examine-chip", ("chip", chip)));
    }

    private void OnEmagged(Entity<CryptoMinerComponent> ent, ref GotEmaggedEvent args)
    {
        if (!_emag.CompareFlag(args.Type, EmagType.Interaction))
            return;

        if (_emag.CheckFlag(ent, EmagType.Interaction))
            return;

        // Флаг емага ставится после события.
        UpdatePowerLoad(ent, emagged: true);
        args.Handled = true;
    }

    public CryptoMinerChipComponent? GetChip(Entity<CryptoMinerComponent> ent) => _itemSlots.GetItemOrNull(ent, ent.Comp.ChipSlot) is { } chip
            ? CompOrNull<CryptoMinerChipComponent>(chip)
            : null;

    /// <summary>Потребление от ЛКП с учётом емага и чипа, Вт.</summary>
    public float GetPowerDraw(Entity<CryptoMinerComponent> ent, bool emagged)
    {
        var draw = ent.Comp.PowerDraw * (emagged ? ent.Comp.EmaggedPowerMultiplier : 1f);
        if (GetChip(ent) is { } chip)
            draw *= chip.PowerMultiplier;

        return draw;
    }

    /// <summary>Тепловыделение, Вт.</summary>
    public float GetHeatPower(Entity<CryptoMinerComponent> ent, bool emagged)
    {
        var heat = GetPowerDraw(ent, emagged) * ent.Comp.HeatFraction;
        if (GetChip(ent) is { } chip)
            heat *= chip.HeatMultiplier;

        return heat;
    }

    private void UpdatePowerLoad(Entity<CryptoMinerComponent> ent, bool? emagged = null)
    {
        var isEmagged = emagged ?? _emag.CheckFlag(ent, EmagType.Interaction);
        _powerReceiver.SetLoad(ent.Owner, GetPowerDraw(ent, isEmagged));
    }

    protected void SetState(Entity<CryptoMinerComponent> ent, CryptoMinerStatus status, int efficiency, int income)
    {
        if (ent.Comp.Status == status && ent.Comp.Efficiency == efficiency && ent.Comp.IncomePerMinute == income)
            return;

        ent.Comp.Status = status;
        ent.Comp.Efficiency = efficiency;
        ent.Comp.IncomePerMinute = income;
        Dirty(ent);
    }
}
