using Content.Shared._LP.Sponsors;
using Content.Shared.CCVar;
using Content.Shared.Preferences;
using Robust.Shared.Network;
using Robust.Shared.Player;

namespace Content.Server.Preferences.Managers;

public sealed partial class ServerPreferencesManager
{
    /// <summary>
    /// Слоты персонажей игрока: CVar или больше, если у него есть роль из прототипа <see cref="CharacterSlotsPrototype"/>.
    /// </summary>
    public int GetMaxCharacterSlots(ICommonSession? session)
    {
        var slots = _cfg.GetCVar(CCVars.GameMaxCharacterSlots);
        if (session is null)
            return slots;

        foreach (var proto in _prototypeManager.EnumeratePrototypes<CharacterSlotsPrototype>())
        {
            if (proto.Slots > slots && RolesRestrictions.IsAllowed(proto.Requirement, session))
                slots = proto.Slots;
        }

        return slots;
    }

    /// <summary>
    /// Слот можно занять, если он в пределах лимита. Уже занятые слоты за лимитом (например, после окончания подписки)
    /// остаются доступны для правки и удаления.
    /// </summary>
    private bool IsSlotAllowed(NetUserId userId, PlayerPreferences prefs, int slot)
    {
        if (slot < 0)
            return false;

        if (prefs.Characters.ContainsKey(slot))
            return true;

        _playerManager.TryGetSessionById(userId, out var session);
        return slot < GetMaxCharacterSlots(session);
    }

    /// <summary>
    /// Переотправляет настройки, когда у игрока поменялись роли Discord (меняется число слотов).
    /// </summary>
    public void ResendPreferences(ICommonSession session)
    {
        if (_cachedPlayerPrefs.TryGetValue(session.UserId, out var prefsData) && prefsData.PrefsLoaded)
            SendPreferences(session, prefsData.Prefs!);
    }
}
