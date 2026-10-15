using Content.Shared._LP.CryptoMining.EntitySystems;
using Content.Shared.Cargo.Prototypes;
using Content.Shared.Damage;
using Content.Shared.Guidebook;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared._LP.CryptoMining.Components;

/// <summary>
/// Блейд-сервер, который в запитанной стойке на станции приносит кредиты в бюджет станции и греет воздух.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, AutoGenerateComponentPause]
[Access(typeof(SharedCryptoMinerSystem))]
public sealed partial class CryptoMinerComponent : Component
{
    [DataField, GuidebookData]
    public float BaseIncomePerMinute = 100f;

    /// <summary>Потребление от ЛКП, Вт. Нагрузку приёмника выставляет система.</summary>
    [DataField, GuidebookData]
    public float PowerDraw = 2400f;

    /// <summary>Доля потребления, которая уходит теплом в газ тайла стойки.</summary>
    [DataField]
    public float HeatFraction = 0.5f;

    /// <summary>Ниже этого давления (кПа) тепло отводить некуда и майнер не работает.</summary>
    [DataField, GuidebookData]
    public float MinPressure = 20f;

    /// <summary>Пороги температуры, К: до первого эффективность полная, ко второму линейно падает до нуля.</summary>
    [DataField]
    public float OptimalTemperature = 313.15f;

    [DataField]
    public float ShutdownTemperature = 353.15f;

    /// <summary>Выше этой температуры (К) майнер каждую секунду получает <see cref="OverheatDamage"/>.</summary>
    [DataField]
    public float DamageTemperature = 373.15f;

    [DataField]
    public DamageSpecifier OverheatDamage = new()
    {
        DamageDict = new()
        {
            { "Heat", 1 },
        },
    };

    [DataField]
    public float EmaggedIncomeMultiplier = 2f;

    [DataField]
    public float EmaggedPowerMultiplier = 2f;

    [DataField]
    public string ChipSlot = "crypto_chip";

    /// <summary>Счёт для дохода. Не задан - доход распределяется как выручка карго.</summary>
    [DataField]
    public ProtoId<CargoAccountPrototype>? Account;

    [DataField]
    public TimeSpan PayoutInterval = TimeSpan.FromMinutes(1);

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan NextPayout;

    [DataField]
    public float PendingIncome;

    // Состояние для осмотра на клиенте.
    [DataField, AutoNetworkedField]
    public CryptoMinerStatus Status = CryptoMinerStatus.NotInRack;

    [DataField, AutoNetworkedField]
    public int Efficiency;

    [DataField, AutoNetworkedField]
    public int IncomePerMinute;
}

[Serializable, NetSerializable]
public enum CryptoMinerStatus : byte
{
    NotInRack,
    NoPower,
    NoStation,
    NoCooling,
    Overheated,
    Working,
}
