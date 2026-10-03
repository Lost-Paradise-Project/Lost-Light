using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
    /*
     * Station Goal
     */

    /// <summary>
    /// Send station goal on round start or not.
    /// </summary>
    public static readonly CVarDef<bool> StationGoal =
        CVarDef.Create("game.station_goal", true, CVar.SERVERONLY);

    /*
     * TTS (ntts.fdev.team)
     */

    /// <summary>
    /// Адрес генерации речи ntts (GET с параметрами speaker, text, ext, effect).
    /// </summary>
    public static readonly CVarDef<string> TTSApiUrl =
        CVarDef.Create("tts.api_url", "https://ntts.fdev.team/api/v1/tts", CVar.SERVERONLY);

    /// <summary>
    /// Токен ntts (Authorization: Bearer). Только в закрытом конфиге сервера.
    /// </summary>
    public static readonly CVarDef<string> TTSApiToken =
        CVarDef.Create("tts.api_token", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

    /// <summary>
    /// Таймаут запроса к ntts в секундах.
    /// </summary>
    public static readonly CVarDef<int> TTSApiTimeout =
        CVarDef.Create("tts.api_timeout", 5, CVar.SERVERONLY);

    /// <summary>
    /// Сколько последних фраз держать в кэше в памяти. 0 - без кэша.
    /// </summary>
    public static readonly CVarDef<int> TTSMaxCache =
        CVarDef.Create("tts.max_cache", 250, CVar.SERVERONLY);

    /// <summary>
    /// Голос ntts, если у сущности нет своего голоса.
    /// </summary>
    public static readonly CVarDef<string> TTSDefaultSpeaker =
        CVarDef.Create("tts.default_speaker", "briman", CVar.SERVERONLY);

    /// <summary>
    /// Голос ntts для объявлений без говорящего.
    /// </summary>
    public static readonly CVarDef<string> TTSAnnounceSpeaker =
        CVarDef.Create("tts.announce_speaker", "adjutant", CVar.SERVERONLY);
}
