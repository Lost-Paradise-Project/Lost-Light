using Content.Shared._NullLink;
using Robust.Shared.Prototypes;

namespace Content.Shared.Humanoid.Markings;

public sealed partial class MarkingPrototype
{
    /// <summary>
    /// Роли Discord, нужные для этого маркинга (спонсорские маркинги). Без значения маркинг доступен всем.
    /// </summary>
    [DataField]
    public ProtoId<RoleRequirementPrototype>? RolesRequirement;
}
