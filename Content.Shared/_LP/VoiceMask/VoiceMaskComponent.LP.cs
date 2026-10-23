using Content.Shared._Starlight.TextToSpeech;
using Robust.Shared.Prototypes;

namespace Content.Shared.VoiceMask;

public sealed partial class VoiceMaskComponent
{
    [DataField]
    public ProtoId<VoicePrototype>? VoiceMaskTtsVoice;
}
