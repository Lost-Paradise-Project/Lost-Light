using Content.Shared.Mobs;
using Robust.Shared.GameStates;

namespace Content.Shared._LP.Viewcone;

/// <summary>
/// Меняет угол конуса зрения (<see cref="Content.Shared._ES.Viewcone.Components.ESViewconeComponent"/>)
/// в зависимости от состояния моба. Итоговая добавка - наименьшая из модификаторов одежды, статус-эффектов
/// и состояния моба (они не складываются, см. <see cref="Content.Shared._ES.Viewcone.Components.ESViewconeGetAngleModifierEvent"/>).
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class ViewconeMobStateModifierComponent : Component
{
    /// <summary>
    /// Добавка к углу в градусах для каждого состояния. Состояния без записи угол не меняют.
    /// </summary>
    [DataField, AutoNetworkedField]
    public Dictionary<MobState, float> Modifiers = new();
}
