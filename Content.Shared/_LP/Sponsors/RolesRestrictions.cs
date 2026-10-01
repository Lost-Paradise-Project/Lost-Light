using System.Linq;
using Content.Shared._NullLink;
using Content.Shared.Humanoid;
using Content.Shared.Humanoid.Markings;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;

namespace Content.Shared._LP.Sponsors;

/// <summary>
/// Проверки контента, закрытого ролями Discord через NullLink (спонсорские маркинги, расы и т. п.).
/// </summary>
public static class RolesRestrictions
{
    /// <summary>
    /// Без требования контент доступен всем. С требованием - только игроку с любой из ролей прототипа.
    /// </summary>
    public static bool IsAllowed(ProtoId<RoleRequirementPrototype>? requirement, ICommonSession? session)
    {
        if (requirement is null)
            return true;

        if (session is null)
            return false;

        var protoManager = IoCManager.Resolve<IPrototypeManager>();
        if (!protoManager.TryIndex(requirement.Value, out var proto))
            return false;

        return IoCManager.Resolve<ISharedNullLinkPlayerRolesReqManager>().IsAnyRole(session, proto.Roles);
    }

    public static bool IsAllowed(MarkingPrototype marking, ICommonSession? session)
        => IsAllowed(marking.RolesRequirement, session);

    /// <summary>
    /// Убирает из списка маркинги, которые игроку недоступны.
    /// </summary>
    public static IReadOnlyDictionary<string, MarkingPrototype> FilterMarkings(
        IReadOnlyDictionary<string, MarkingPrototype> markings,
        ICommonSession? session)
    {
        if (markings.Values.All(m => m.RolesRequirement is null))
            return markings;

        return markings
            .Where(pair => IsAllowed(pair.Value, session))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    /// <summary>
    /// <see cref="FilterMarkings"/> для локального игрока (клиентские меню).
    /// </summary>
    public static IReadOnlyDictionary<string, MarkingPrototype> FilterMarkingsForLocal(
        IReadOnlyDictionary<string, MarkingPrototype> markings)
        => FilterMarkings(markings, IoCManager.Resolve<ISharedPlayerManager>().LocalSession);

    /// <summary>
    /// Снимает с внешности недоступные маркинги и причёски.
    /// </summary>
    public static HumanoidCharacterAppearance FilterAppearance(HumanoidCharacterAppearance appearance, ICommonSession? session)
    {
        var markingManager = IoCManager.Resolve<MarkingManager>();

        appearance.Markings.RemoveAll(m =>
            markingManager.Markings.TryGetValue(m.MarkingId, out var proto) && !IsAllowed(proto, session));

        if (markingManager.Markings.TryGetValue(appearance.HairStyleId, out var hair) && !IsAllowed(hair, session))
            appearance.HairStyleId = HairStyles.DefaultHairStyle;

        if (markingManager.Markings.TryGetValue(appearance.FacialHairStyleId, out var facialHair) && !IsAllowed(facialHair, session))
            appearance.FacialHairStyleId = HairStyles.DefaultFacialHairStyle;

        return appearance;
    }
}
