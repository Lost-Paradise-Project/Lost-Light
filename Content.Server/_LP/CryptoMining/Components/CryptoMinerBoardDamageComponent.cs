using Content.Server._LP.CryptoMining.EntitySystems;
using Content.Shared.Damage;

namespace Content.Server._LP.CryptoMining.Components;

/// <summary>
/// Урон разобранного майнера на его плате, чтобы пересборка не лечила майнер.
/// </summary>
[RegisterComponent, Access(typeof(CryptoMinerSystem))]
public sealed partial class CryptoMinerBoardDamageComponent : Component
{
    [DataField]
    public DamageSpecifier Damage = new();
}
