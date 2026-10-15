using Content.Server._LP.CryptoMining.EntitySystems;
using Content.Shared.Damage;

namespace Content.Server._LP.CryptoMining.Components;

/// <summary>
/// Урон разобранного крипто-майнера, сохранённый на его плате. Без этого пересборка (лом, затем отвёртка)
/// давала бы новый майнер с полным здоровьем и заменяла бы ремонт сваркой.
/// </summary>
[RegisterComponent, Access(typeof(CryptoMinerSystem))]
public sealed partial class CryptoMinerBoardDamageComponent : Component
{
    [DataField]
    public DamageSpecifier Damage = new();
}
