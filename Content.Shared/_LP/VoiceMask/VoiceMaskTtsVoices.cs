using Content.Shared._Starlight.TextToSpeech;
using Robust.Shared.Serialization;

namespace Content.Shared._LP.VoiceMask;

/// <summary>
/// Выбор голоса TTS в окне голосовой маски.
/// </summary>
[Serializable, NetSerializable]
public sealed class VoiceMaskChangeTtsVoiceMessage(string? voice) : BoundUserInterfaceMessage
{
    /// <summary>ID голоса или null, чтобы не подменять голос.</summary>
    public readonly string? Voice = voice;
}

public static class VoiceMaskTtsVoices
{
    /// <summary>
    /// Маска предлагает те же голоса, что игрок видит при создании персонажа: рабочие голоса ntts для гуманоидов.
    /// Клиент и сервер проверяют голос одним правилом.
    /// </summary>
    public static bool IsAllowed(VoicePrototype voice)
    {
        return voice.Speaker != null && !voice.Silicon;
    }
}
