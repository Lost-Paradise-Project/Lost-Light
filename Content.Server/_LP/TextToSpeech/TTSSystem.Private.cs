using System.Threading.Tasks;
using Content.Shared._Starlight.TextToSpeech;
using Robust.Shared.Player;

namespace Content.Server._Starlight.TextToSpeech;

/// <summary>
/// Озвучка, которую слышит один игрок: приветствие автоответчика в трубке звонящего.
/// </summary>
public sealed partial class TTSSystem
{
    public async void PlayPrivateSpeech(EntityUid recipient, EntityUid voiceSource, string text, TTSEffect effect)
    {
        if (!_isEnabled || text.Length > MaxChars)
            return;

        await Task.Yield();
        try
        {
            if (Deleted(recipient) || Deleted(voiceSource) || !TryComp<ActorComponent>(recipient, out var actor))
                return;

            if (_ignoredRecipients.Contains(actor.PlayerSession))
                return;

            await GenerateAndStream(TTSType.System, ResolveSpeakerVoice(voiceSource), CleanText(text), Filter.SinglePlayer(actor.PlayerSession), effect);
        }
        catch (TaskCanceledException ex)
        {
            _sawmill.Info($"TTS private was cancelled: {ex.Message}");
        }
        catch (Exception ex)
        {
            _sawmill.Error($"TTS private error: {ex.Message}");
        }
    }
}
