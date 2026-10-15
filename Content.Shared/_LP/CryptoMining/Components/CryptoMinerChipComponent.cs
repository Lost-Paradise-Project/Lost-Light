using Content.Shared._LP.CryptoMining.EntitySystems;
using Content.Shared.Guidebook;
using Robust.Shared.GameStates;

namespace Content.Shared._LP.CryptoMining.Components;

/// <summary>
/// Апгрейд-чип для слота крипто-майнера.
/// </summary>
[RegisterComponent, NetworkedComponent]
[Access(typeof(SharedCryptoMinerSystem))]
public sealed partial class CryptoMinerChipComponent : Component
{
    [DataField, GuidebookData]
    public float IncomeMultiplier = 1f;

    [DataField, GuidebookData]
    public float PowerMultiplier = 1f;

    /// <summary>Множитель тепла при том же потреблении.</summary>
    [DataField, GuidebookData]
    public float HeatMultiplier = 1f;
}
