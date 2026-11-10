using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
    /*
     * TTS (ntts.fdev.team)
     */

    /// <summary>
    /// Адрес генерации речи ntts (GET с параметрами speaker, text, ext, effect).
    /// </summary>
    public static readonly CVarDef<string> TtsApiUrl =
        CVarDef.Create("tts.api_url", "https://ntts.fdev.team/api/v1/tts", CVar.SERVERONLY);

    /// <summary>
    /// Токен ntts (Authorization: Bearer). Только в закрытом конфиге сервера.
    /// </summary>
    public static readonly CVarDef<string> TtsApiToken =
        CVarDef.Create("tts.api_token", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

    /// <summary>
    /// Таймаут запроса к ntts в секундах.
    /// </summary>
    public static readonly CVarDef<int> TtsApiTimeout =
        CVarDef.Create("tts.api_timeout", 5, CVar.SERVERONLY);

    /// <summary>
    /// Сколько последних фраз держать в кэше в памяти. 0 - без кэша.
    /// </summary>
    public static readonly CVarDef<int> TtsMaxCache =
        CVarDef.Create("tts.max_cache", 250, CVar.SERVERONLY);

    /// <summary>
    /// Голос ntts, если у сущности нет своего голоса.
    /// </summary>
    public static readonly CVarDef<string> TtsDefaultSpeaker =
        CVarDef.Create("tts.default_speaker", "briman", CVar.SERVERONLY);

    /// <summary>
    /// Голос ntts для объявлений без говорящего.
    /// </summary>
    public static readonly CVarDef<string> TtsAnnounceSpeaker =
        CVarDef.Create("tts.announce_speaker", "adjutant", CVar.SERVERONLY);

    /// <summary>
    /// Минимальная пауза в секундах между озвученными репликами одной сущности. Лишние реплики не озвучиваются. 0 - без ограничения.
    /// </summary>
    public static readonly CVarDef<float> TTSEntityCooldown =
        CVarDef.Create("tts.entity_cooldown", 2f, CVar.SERVERONLY);
}
