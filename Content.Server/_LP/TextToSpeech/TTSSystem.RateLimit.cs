using Content.Shared.CCVar;
using Robust.Shared.Timing;

namespace Content.Server._Starlight.TextToSpeech;

/// <summary>
/// Простой лимит частоты: одна сущность озвучивается не чаще, чем раз в tts.entity_cooldown секунд.
/// Спам репликами иначе тратит запросы и квоту ntts.
/// </summary>
public sealed partial class TTSSystem
{
    private const int CooldownPruneThreshold = 512;

    [Dependency] private IGameTiming _gameTiming = default!;

    private readonly Dictionary<EntityUid, TimeSpan> _nextSpeech = new();
    private readonly Dictionary<EntityUid, TimeSpan> _nextRadioSpeech = new();

    /// <summary>
    /// Занимает паузу сущности. false - сущность говорила совсем недавно, реплику озвучивать не нужно.
    /// Речь и рация считаются отдельно: одна реплика в рацию идёт сразу и вслух, и по радио.
    /// </summary>
    private bool TryUseSpeechCooldown(EntityUid uid, bool radio = false)
    {
        var cooldown = _cfg.GetCVar(CCVars.TTSEntityCooldown);
        if (cooldown <= 0f)
            return true;

        var now = _gameTiming.CurTime;
        var cooldowns = radio ? _nextRadioSpeech : _nextSpeech;
        if (cooldowns.TryGetValue(uid, out var next) && now < next)
            return false;

        if (cooldowns.Count >= CooldownPruneThreshold)
            PruneSpeechCooldowns(cooldowns, now);

        cooldowns[uid] = now + TimeSpan.FromSeconds(cooldown);
        return true;
    }

    private void PruneSpeechCooldowns(Dictionary<EntityUid, TimeSpan> cooldowns, TimeSpan now)
    {
        var expired = new List<EntityUid>();
        foreach (var (uid, next) in cooldowns)
        {
            if (now >= next || Deleted(uid))
                expired.Add(uid);
        }

        foreach (var uid in expired)
            cooldowns.Remove(uid);
    }
}
