using Content.Shared.Preferences;
using Content.Shared.Preferences.Loadouts;
using Content.Shared.Preferences.Loadouts.Effects;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Utility;

namespace Content.Shared._LP.Sponsors;

/// <summary>
/// Личный предмет: лодаут доступен только перечисленным аккаунтам SS14 (UUID).
/// </summary>
public sealed partial class PersonalLoadoutEffect : LoadoutEffect
{
    [DataField(required: true)]
    public List<NetUserId> Users = new();

    public override bool Validate(HumanoidCharacterProfile profile, RoleLoadout loadout, ICommonSession? session,
        IDependencyCollection collection, out FormattedMessage reason)
    {
        var success = session is not null && Users.Contains(session.UserId);

        reason = FormattedMessage.FromMarkupPermissive(Loc.GetString(
            success ? "loadout-personal-pass" : "loadout-personal-fail"));

        return success;
    }
}
