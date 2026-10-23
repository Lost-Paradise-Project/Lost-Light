using Content.Shared._Starlight.TextToSpeech;
using Content.Shared.Chat;
using Robust.Shared.Prototypes;

namespace Content.Server._Starlight.TextToSpeech;

/// <summary>
/// Голос говорящего с учётом подмены: голосовая маска, имплант и подобное задают его через <see cref="TransformSpeakerNameEvent"/>.
/// </summary>
public sealed partial class TTSSystem
{
    /// <summary>
    /// Голос, которым говорящий звучит для остальных: подменённый, если он есть, иначе его собственный.
    /// Все места, где озвучивается говорящий (речь, рация, релей, запись на кассету), берут голос только здесь.
    /// </summary>
    public int ResolveSpeakerVoice(EntityUid speaker, int? fallbackVoice = null)
    {
        if (GetVoiceOverride(speaker) is { } voice)
            return voice.Voice;

        return GetOrAssignVoice(speaker, fallbackVoice: fallbackVoice);
    }

    /// <summary>
    /// ID голоса для записи на кассету: подменённый, если он есть, иначе уже назначенный говорящему.
    /// Свой голос не назначается, если говорящему он ещё не выдан.
    /// </summary>
    public ProtoId<VoicePrototype>? ResolveSpeakerVoiceId(EntityUid speaker)
    {
        if (GetVoiceOverride(speaker) is { } voice)
            return voice.ID;

        return TryComp<TextToSpeechComponent>(speaker, out var tts) ? tts.VoicePrototypeId : null;
    }

    private VoicePrototype? GetVoiceOverride(EntityUid speaker)
    {
        if (Deleted(speaker))
            return null;

        var ev = new TransformSpeakerNameEvent(speaker, string.Empty);
        RaiseLocalEvent(speaker, ev);

        if (ev.VoiceOverride is not { } id
            || !_prototypeManager.TryIndex(id, out var proto)
            || proto.Speaker == null)
            return null;

        return proto;
    }
}
