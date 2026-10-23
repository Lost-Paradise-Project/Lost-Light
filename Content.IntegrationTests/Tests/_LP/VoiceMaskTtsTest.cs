using Content.IntegrationTests.Fixtures;
using Content.Server._Starlight.TextToSpeech;
using Content.Shared._LP.VoiceMask;
using Content.Shared.Chat;
using Content.Shared.Inventory;
using Content.Shared.VoiceMask;

namespace Content.IntegrationTests.Tests._LP;

/// <summary>
/// Голосовая маска подменяет голос TTS через <see cref="TransformSpeakerNameEvent"/>,
/// а выбор голоса клиентом проверяется на сервере.
/// </summary>
public sealed class VoiceMaskTtsTest : GameTest
{
    private const string MaskProto = "ClothingMaskGasVoiceChameleon";
    private const string AllowedVoice = "ntts_abaddon_dota_2";
    private const string SiliconVoice = "ntts_adjutant";

    [Test]
    public async Task MaskOverridesVoiceOnlyWhenActive()
    {
        var map = await Pair.CreateTestMap();

        await Server.WaitAssertion(() =>
        {
            var inventory = SEntMan.System<InventorySystem>();
            var tts = SEntMan.System<TTSSystem>();

            var mob = SEntMan.SpawnEntity("MobHuman", map.GridCoords);
            var mask = SEntMan.SpawnEntity(MaskProto, map.GridCoords);
            Assert.That(inventory.TryEquip(mob, mask, "mask", force: true));

            var comp = SEntMan.GetComponent<VoiceMaskComponent>(mask);
            comp.VoiceMaskTtsVoice = AllowedVoice;

            var voice = SProtoMan.Index<Content.Shared._Starlight.TextToSpeech.VoicePrototype>(AllowedVoice);
            Assert.That(tts.ResolveSpeakerVoice(mob), Is.EqualTo(voice.Voice));
            Assert.That(tts.ResolveSpeakerVoiceId(mob)?.Id, Is.EqualTo(AllowedVoice));

            // выключенная маска голос не подменяет
            comp.Active = false;
            Assert.That(tts.ResolveSpeakerVoiceId(mob)?.Id, Is.Not.EqualTo(AllowedVoice));

            // без выбранного голоса маска голос не меняет
            comp.Active = true;
            comp.VoiceMaskTtsVoice = null;
            Assert.That(tts.ResolveSpeakerVoiceId(mob)?.Id, Is.Not.EqualTo(AllowedVoice));
        });
    }

    [Test]
    public async Task ServerRejectsUnavailableVoices()
    {
        var map = await Pair.CreateTestMap();

        await Server.WaitAssertion(() =>
        {
            var mob = SEntMan.SpawnEntity("MobHuman", map.GridCoords);
            var mask = SEntMan.SpawnEntity(MaskProto, map.GridCoords);
            var comp = SEntMan.GetComponent<VoiceMaskComponent>(mask);

            void Send(string? voice)
            {
                var msg = new VoiceMaskChangeTtsVoiceMessage(voice) { Actor = mob };
                SEntMan.EventBus.RaiseLocalEvent(mask, msg);
            }

            Send(AllowedVoice);
            Assert.That(comp.VoiceMaskTtsVoice?.Id, Is.EqualTo(AllowedVoice));

            // голос синтетиков и несуществующий голос не принимаются, прежний выбор остаётся
            Send(SiliconVoice);
            Assert.That(comp.VoiceMaskTtsVoice?.Id, Is.EqualTo(AllowedVoice));

            Send("NoSuchVoice");
            Assert.That(comp.VoiceMaskTtsVoice?.Id, Is.EqualTo(AllowedVoice));

            // пустой выбор снимает подмену
            Send(null);
            Assert.That(comp.VoiceMaskTtsVoice, Is.Null);
        });
    }
}
