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
/// Блейд-сервер, который в запитанной стойке на станции приносит кредиты в бюджет станции и греет воздух вокруг.
/// Число майнеров ограничивают питание (полная стойка занимает целый ЛКП) и охлаждение.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, AutoGenerateComponentPause]
[Access(typeof(SharedCryptoMinerSystem))]
public sealed partial class CryptoMinerComponent : Component
{
    /// <summary>
    /// Доход в минуту при полной эффективности.
    /// </summary>
    [DataField, GuidebookData]
    public float BaseIncomePerMinute = 100f;

    /// <summary>
    /// Потребление майнера от ЛКП, Вт.
    /// Нагрузку приёмника питания выставляет система, в прототипе её задавать не нужно.
    /// </summary>
    [DataField, GuidebookData]
    public float PowerDraw = 2400f;

    /// <summary>
    /// Какая доля потребления уходит теплом в газ тайла стойки. Главная ручка скорости нагрева серверной.
    /// </summary>
    [DataField]
    public float HeatFraction = 0.5f;

    /// <summary>
    /// Ниже этого давления газа вокруг стойки майнеру нечем отводить тепло, и он не работает, кПа.
    /// </summary>
    [DataField, GuidebookData]
    public float MinPressure = 20f;

    /// <summary>
    /// До этой температуры майнер работает на полную эффективность, К.
    /// </summary>
    [DataField]
    public float OptimalTemperature = 313.15f;

    /// <summary>
    /// При этой температуре эффективность падает до нуля, К. Между порогами - линейно.
    /// </summary>
    [DataField]
    public float ShutdownTemperature = 353.15f;

    /// <summary>
    /// Выше этой температуры майнер получает <see cref="OverheatDamage"/> каждую секунду, К.
    /// </summary>
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

    /// <summary>
    /// Множитель дохода емагнутого майнера.
    /// </summary>
    [DataField]
    public float EmaggedIncomeMultiplier = 2f;

    /// <summary>
    /// Множитель потребления (а значит, и тепла) емагнутого майнера.
    /// </summary>
    [DataField]
    public float EmaggedPowerMultiplier = 2f;

    /// <summary>
    /// Слот для <see cref="CryptoMinerChipComponent">апгрейд-чипа</see>, описывается в ItemSlots прототипа.
    /// </summary>
    [DataField]
    public string ChipSlot = "crypto_chip";

    /// <summary>
    /// Счёт станции для дохода. Если не задан - доход распределяется как выручка карго.
    /// </summary>
    [DataField]
    public ProtoId<CargoAccountPrototype>? Account;

    /// <summary>
    /// Как часто накопленный доход переводится на счёт станции.
    /// </summary>
    [DataField]
    public TimeSpan PayoutInterval = TimeSpan.FromMinutes(1);

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan NextPayout;

    /// <summary>
    /// Накопленный, но ещё не переведённый доход.
    /// </summary>
    [DataField]
    public float PendingIncome;

    [DataField, AutoNetworkedField]

    public CryptoMinerStatus Status = CryptoMinerStatus.NotInRack;

    /// <summary>
    /// Текущая эффективность в процентах, для осмотра.
    /// </summary>
    [DataField, AutoNetworkedField]
    public int Efficiency;

    /// <summary>
    /// Текущий доход в минуту с учётом нагрева и убывающей отдачи, для осмотра.
    /// </summary>
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
