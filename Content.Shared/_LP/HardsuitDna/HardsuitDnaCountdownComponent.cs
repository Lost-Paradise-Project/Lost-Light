using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared._LP.HardsuitDna;

/// <summary>
/// Идёт отсчёт до взрыва скафандра с чужим носителем. Сетевой, потому что пока он есть,
/// клиент должен предсказывать снятие скафандра без <c>ClothingComponent.UnequipDelay</c>.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentPause]
public sealed partial class HardsuitDnaCountdownComponent : Component
{
    [ViewVariables]
    public EntityUid Wearer;

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan EndTime;

    /// <summary>
    /// Сколько секунд осталось объявить голосом; объявляется, когда до конца остаётся не больше этого числа.
    /// </summary>
    [ViewVariables]
    public int NextAnnounce;
}
