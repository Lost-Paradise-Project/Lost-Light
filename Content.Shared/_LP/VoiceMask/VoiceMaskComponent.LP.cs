using Content.Shared._Starlight.TextToSpeech;
using Robust.Shared.Prototypes;

namespace Content.Shared.VoiceMask;

public sealed partial class VoiceMaskComponent
{
    /// <summary>
    ///     Голос TTS, которым говорит владелец маски, пока она включена. Если null, голос не подменяется.
    /// </summary>
    [DataField]
    public ProtoId<VoicePrototype>? VoiceMaskTtsVoice;
}
