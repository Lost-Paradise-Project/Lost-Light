using System.Threading.Tasks;
using Content.Shared._Starlight.Language;
using Content.Shared._Starlight.TextToSpeech;
using Content.Shared.Chat;
using Robust.Shared.Player;

namespace Content.Server._Starlight.TextToSpeech;

/// <summary>
/// Озвучка реплик, которые устройство повторяет за говорящим: интерком и ручная рация, телефон и голопад.
/// Голос - говорящего, звук идёт от устройства.
/// </summary>
public sealed partial class TTSSystem
{
    public async void PlayRelayedSpeech(EntityUid device, EntityUid messageSource, string text, LanguagePrototype? language, bool whisper, TTSEffect effect)
    {
        if (!_isEnabled || text.Length > MaxChars)
            return;

        if (language != null && !language.Speech.RequireSpeech && !language.Speech.RequireSound)
            return;

        await Task.Yield();
        try
        {
            if (Deleted(device) || Deleted(messageSource))
                return;

            var filter = whisper
                ? Filter.Empty().AddInRange(_xforms.GetMapCoordinates(device), SharedChatSystem.WhisperClearRange)
                : Filter.Pvs(device, 1F);

            filter = filter.RemovePlayers(_ignoredRecipients)
                .RemoveWhere(x => x.AttachedEntity == messageSource
                    || language != null
                    && x.AttachedEntity.HasValue
                    && !_language.CanUnderstand(x.AttachedEntity.Value, language.ID));

            var voice = GetOrAssignVoice(messageSource);
            await GenerateAndStream(TTSType.IG, voice, CleanText(text), filter, effect, null, device,
                volume: whisper ? WhisperVoiceVolumeModifier : 1f);
        }
        catch (TaskCanceledException ex)
        {
            _sawmill.Info($"TTS relay was cancelled: {ex.Message}");
        }
        catch (Exception ex)
        {
            _sawmill.Error($"TTS relay error: {ex.Message}");
        }
    }
}
