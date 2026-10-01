using Content.Shared._NullLink;
using Robust.Shared.Prototypes;

namespace Content.Shared.Humanoid.Prototypes;

public sealed partial class SpeciesPrototype
{
    /// <summary>
    /// Роли Discord, нужные для выбора этой расы (спонсорские расы). Без значения раса доступна всем.
    /// </summary>
    [DataField]
    public ProtoId<RoleRequirementPrototype>? RolesRequirement;
}
