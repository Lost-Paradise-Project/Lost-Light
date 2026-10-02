using Content.Server.Preferences.Managers;
using Robust.Shared.Player;

namespace Content.Server._NullLink.PlayerData;

public sealed partial class NullLinkPlayerManager
{
    [Dependency] private IServerPreferencesManager _lpPreferences = default!;

    /// <summary>
    /// Роли Discord поменялись: обновляем то, что от них зависит у нас (число слотов персонажей).
    /// </summary>
    private void LPRolesChanged(ICommonSession session)
    {
        if (_lpPreferences is ServerPreferencesManager prefs)
            _taskManager.RunOnMainThread(() => prefs.ResendPreferences(session));
    }
}
