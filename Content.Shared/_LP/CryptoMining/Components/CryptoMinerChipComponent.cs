using Content.Shared._LP.CryptoMining.EntitySystems;
using Content.Shared.Guidebook;
using Robust.Shared.GameStates;

namespace Content.Shared._LP.CryptoMining.Components;

/// <summary>
/// Апгрейд-чип, который вставляется в слот крипто-майнера и меняет его доход, потребление и нагрев.
/// </summary>
[RegisterComponent, NetworkedComponent]
[Access(typeof(SharedCryptoMinerSystem))]
public sealed partial class CryptoMinerChipComponent : Component
{
    /// <summary>
    /// Множитель дохода.
    /// </summary>
    [DataField, GuidebookData]
    public float IncomeMultiplier = 1f;

    /// <summary>
    /// Множитель потребления от ЛКП.
    /// </summary>
    [DataField, GuidebookData]
    public float PowerMultiplier = 1f;

    /// <summary>
    /// Какая доля потребления уходит в тепло. Охлаждающий чип отдаёт меньше тепла при том же потреблении.
    /// </summary>
    [DataField, GuidebookData]
    public float HeatMultiplier = 1f;
}
