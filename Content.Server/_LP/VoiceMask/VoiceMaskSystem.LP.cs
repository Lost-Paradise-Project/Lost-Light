using Content.Shared._LP.VoiceMask;
using Content.Shared._Starlight.TextToSpeech;
using Content.Shared.ActionBlocker;
using Content.Shared.Database;
using Content.Shared.Interaction;
using Content.Shared.Popups;
using Content.Shared.VoiceMask;
using Robust.Shared.Prototypes;

namespace Content.Server.VoiceMask;

public sealed partial class VoiceMaskSystem
{
    [Dependency] private ActionBlockerSystem _lpActionBlocker = default!;
    [Dependency] private SharedInteractionSystem _lpInteraction = default!;

    private void InitializeLP() => SubscribeLocalEvent<VoiceMaskComponent, VoiceMaskChangeTtsVoiceMessage>(OnChangeTtsVoice);

    /// <summary>
    /// Клиенту нельзя доверять ID голоса: принимаем только те голоса, что доступны в создании персонажа.
    /// </summary>
    private void OnChangeTtsVoice(Entity<VoiceMaskComponent> entity, ref VoiceMaskChangeTtsVoiceMessage message)
    {
        if (!_lpActionBlocker.CanInteract(message.Actor, entity) || !_lpInteraction.InRangeUnobstructed(message.Actor, entity.Owner))
            return;

        ProtoId<VoicePrototype>? voice = null;

        if (message.Voice is { } id)
        {
            if (!_proto.TryIndex<VoicePrototype>(id, out var proto) || !VoiceMaskTtsVoices.IsAllowed(proto))
            {
                _popupSystem.PopupEntity(Loc.GetString("voice-mask-popup-voice-failure"), entity, message.Actor, PopupType.SmallCaution);
                return;
            }

            voice = proto.ID;
        }

        entity.Comp.VoiceMaskTtsVoice = voice;
        _adminLogger.Add(LogType.Action, LogImpact.Medium, $"{ToPrettyString(message.Actor):player} set TTS voice of {ToPrettyString(entity):mask}: {voice?.Id ?? "none"}");

        _popupSystem.PopupEntity(Loc.GetString("voice-mask-popup-voice-success"), entity, message.Actor);

        UpdateUI(entity);
    }
}
