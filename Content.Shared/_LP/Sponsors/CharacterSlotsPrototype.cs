using Content.Shared._NullLink;
using Robust.Shared.Prototypes;

namespace Content.Shared._LP.Sponsors;

/// <summary>
/// Число слотов персонажей для игроков с ролями Discord.
/// Игрок получает наибольшее значение из подходящих прототипов, без них - CVar game.maxcharacterslots.
/// </summary>
[Prototype]
public sealed partial class CharacterSlotsPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;

    [DataField(required: true)]
    public ProtoId<RoleRequirementPrototype> Requirement;

    [DataField(required: true)]
    public int Slots;
}
