using Content.Server.Chat.Managers;
using Content.Server._LP.Phones;
using Content.Server._Starlight.TextToSpeech;
using Content.Shared.Audio;
using Content.Shared.Chat;
using Content.Shared.Physics;
using Content.Shared.Popups;
using Content.Shared.Radio.Components;
using Content.Shared.Speech;
using Content.Shared._Starlight.Language.Systems;
using Content.Shared._Starlight.TextToSpeech;
using Content.Shared._Trauma.Phones;
using Content.Shared._Trauma.Phones.Components;
using Content.Shared._Trauma.Phones.Events;
using Content.Shared._Trauma.Phones.Systems;
using Robust.Server.GameObjects;
using Robust.Shared.Audio;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Containers;
using Robust.Shared.Map;
using Robust.Shared.Physics;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Server._Trauma.Phones;

public sealed partial class RotaryPhoneSystem : SharedRotaryPhoneSystem
{
    [Dependency] private SharedChatSystem _chat = default!;
    [Dependency] private IChatManager _chatManager = default!;
    [Dependency] private SharedAudioSystem _audio = default!;
    [Dependency] private UserInterfaceSystem _ui = default!;
    [Dependency] private SharedLanguageSystem _language = default!;
    [Dependency] private TTSSystem _tts = default!;
    [Dependency] private SharedPopupSystem _popup = default!; // LP edit
    [Dependency] private IPrototypeManager _proto = default!; // LP edit

    private const int PhoneNameMaxLength = 32; // LP edit

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RotaryPhoneComponent, ListenEvent>(OnListen);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneKeypadMessage>(OnKeyPadPressed);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneKeypadClearMessage>(OnKeyPadClear);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneBookPressedMessage>(OnPhoneBookButtonPressed);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneNameChangedMessage>(OnPhoneNameChanged);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneCategoryChangedMessage>(OnPhoneCategoryChanged);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneDialedMessage>(OnDial);
        SubscribeLocalEvent<RotaryPhoneComponent, BoundUIOpenedEvent>(OnOpen);
        SubscribeLocalEvent<RotaryPhoneComponent, PhoneHungUpEvent>(OnGotHungUp);
        SubscribeLocalEvent<RotaryPhoneHolderComponent, EntInsertedIntoContainerMessage>(OnPhoneInsertHolder);
        InitializeRingTimeout(); // LP edit
    }

    private void OnGotHungUp(Entity<RotaryPhoneComponent> ent, ref PhoneHungUpEvent args)
    {
        if (!ent.Comp.Connected)
        {
            if (ent.Comp.ConnectedPhoneStand != null)
                UpdateAppearance(ent.Comp.ConnectedPhoneStand.Value, RotaryPhoneVisuals.Base);
            return;
        }

        ent.Comp.SoundEntity = _audio.PlayPvs(ent.Comp.HandUpSoundLocal, ent.Owner, AudioParams.Default.WithMaxDistance(2.5f))?.Entity;

        ent.Comp.ConnectedPhone = null;
        ent.Comp.Connected = false;
        Dirty(ent);
    }

    private void OnPhoneInsertHolder(Entity<RotaryPhoneHolderComponent> ent, ref EntInsertedIntoContainerMessage args)
    {
        if (Deleted(ent.Owner) || Terminating(ent.Owner))
            return;

        // LP edit start - в слот подставки вставляют и автоответчик, обрабатываем только трубку
        if (!TryComp<RotaryPhoneComponent>(args.Entity, out var phone))
            return;
        // LP edit end

        RemComp<JointVisualsComponent>(ent.Owner);
        RemComp<JointComponent>(ent.Owner);
        Dirty(ent);

        // Basically on map init set the phones name to whatever the holders name is so it can be changed in mapping
        if (phone.Name != null || ent.Comp.Name == null) // LP edit
            return;

        phone.Name = ent.Comp.Name;
    }

    private void OnPhoneCategoryChanged(Entity<RotaryPhoneComponent> ent, ref PhoneCategoryChangedMessage args)
    {
        // LP edit start - клиенту не доверяем: только окно переименования и существующая категория
        if (!args.UiKey.Equals(PhoneUiKey.NameChange) || !_proto.HasIndex<PhoneCategoryPrototype>(args.Value))
            return;
        // LP edit end

        ent.Comp.Category = args.Value;
        Dirty(ent); // LP edit
    }

    private void OnPhoneNameChanged(Entity<RotaryPhoneComponent> ent, ref PhoneNameChangedMessage args)
    {
        // LP edit start
        if (!args.UiKey.Equals(PhoneUiKey.NameChange))
            return;

        var name = args.Value.Trim();
        if (name.Length > PhoneNameMaxLength)
            name = name[..PhoneNameMaxLength];

        ent.Comp.Name = string.IsNullOrEmpty(name) ? null : name;
        Dirty(ent);
        // LP edit end
    }

    private void OnOpen(Entity<RotaryPhoneComponent> ent, ref BoundUIOpenedEvent args)
    {
        var state = new GoobPhoneBuiState(GetAllPhoneData());
        _ui.SetUiState(ent.Owner, PhoneUiKey.Key, state);
    }

    private List<PhoneData> GetAllPhoneData()
    {
        var data = new List<PhoneData>();
        var query = EntityQueryEnumerator<RotaryPhoneComponent, TransformComponent>();

        while (query.MoveNext(out _, out var phoneComp, out var xform))
        {
            if (xform.MapID == MapId.Nullspace)
                continue;

            if (phoneComp.PhoneNumber is not {} number|| phoneComp.Category is not {} category)
                continue;

            // LP edit start - скрытые категории клиентам не отправляем
            if (!_proto.TryIndex(category, out var categoryProto) || categoryProto.HideInPhonebook)
                continue;
            // LP edit end

            var phones = new PhoneData(phoneComp.Name ?? Loc.GetString("phone-number-unknown"), category, number);

            data.Add(phones);
        }

        return data;
    }

    private void OnPhoneBookButtonPressed(Entity<RotaryPhoneComponent> ent, ref PhoneBookPressedMessage args)
    {
        ent.Comp.DialedNumber = args.Value;
        Dirty(ent);
    }

    private void OnKeyPadPressed(Entity<RotaryPhoneComponent> ent, ref PhoneKeypadMessage args)
    {
        // LP edit start - только цифра 0-9 и не больше пяти цифр
        if (args.Value is < 0 or > 9)
            return;

        var dialed = (ent.Comp.DialedNumber ?? 0) * 10 + args.Value;
        if (dialed > PhoneNumberMax)
            return;
        // LP edit end

        PlayPhoneSound(ent.AsNullable(), args.Value);
        ent.Comp.DialedNumber = dialed; // LP edit
        Dirty(ent);
    }

    private void OnKeyPadClear(Entity<RotaryPhoneComponent> ent, ref PhoneKeypadClearMessage args)
    {
        ent.Comp.DialedNumber = null;
        Dirty(ent);
    }
    private void PlayPhoneSound(Entity<RotaryPhoneComponent?> ent, int number) // Stolen from nuke code
    {
        if (!Resolve(ent.Owner, ref ent.Comp))
            return;

        var semitoneShift = number - 2;

        var opts = ent.Comp.KeypadPressSound.Params;
        opts = AudioHelpers.ShiftSemitone(opts, semitoneShift).AddVolume(-7f);
        _audio.PlayPvs(ent.Comp.KeypadPressSound, ent.Owner, opts.WithMaxDistance(1f));
    }

    private void OnDial(Entity<RotaryPhoneComponent> ent, ref PhoneDialedMessage args)
    {
        if (ent.Comp.ConnectedPhone != null)
            return;

        var query = EntityQueryEnumerator<RotaryPhoneComponent>();
        while (query.MoveNext(out var phone, out var phoneComp))
        {
            if (ent.Comp.DialedNumber == phoneComp.PhoneNumber && phone != ent.Owner)
            {
                // LP edit start
                if (!IsLineWorking(ent, phone, phoneComp))
                {
                    RefuseCall(ent);
                    break;
                }
                // LP edit end

                DoCallLogic(phoneComp, ent, phone);
                break;
            }
        }
    }

    private void OnListen(Entity<RotaryPhoneComponent> ent, ref ListenEvent args)
    {
        if (HasComp<RotaryPhoneComponent>(args.Source)
            || args.Source == ent.Owner
            || HasComp<RadioSpeakerComponent>(args.Source)
            || ent.Comp.ConnectedPhone is not {} connected
            || !TryComp(connected, out RotaryPhoneComponent? otherPhoneComponent))
            return;

        // LP edit start - имя говорящего с учётом голосовой маски
        var nameEv = new TransformSpeakerNameEvent(args.Source, Name(args.Source));
        RaiseLocalEvent(args.Source, nameEv);
        var speakerName = nameEv.VoiceName;
        // LP edit end

        // LP edit start - автоответчик слушает ещё не принятый вызов, остальное только во время разговора
        if (_answering.TryRecord(ent, args.Source, speakerName, args.Message))
            return;

        if (!ent.Comp.Connected || !otherPhoneComponent.Connected)
            return;

        _bug.RecordRotary(ent, args.Source, args.Message);
        _bug.RecordRotary(connected, args.Source, args.Message);
        // LP edit end

        if (otherPhoneComponent.SpeakerPhone)
        {
            // сообщение говорит телефон на громкой связи: язык говорящего сохраняем, голос - его же
            _chat.TrySendInGameICMessage(connected,
                args.Message,
                InGameICChatType.Speak,
                ChatTransmitRange.HideChat,
                hideLog: true,
                nameOverride: speakerName, // LP edit
                checkRadioPrefix: false,
                languageOverride: args.Language);
            _tts.PlayRelayedSpeech(connected, args.Source, args.Message, args.Language, false, TTSEffect.Phone);

            return;
        }


        if (!TryComp(otherPhoneComponent.ConnectedPlayer, out ActorComponent? actor) || otherPhoneComponent.ConnectedPlayer == null)
            return;

        var sound = _audio.ResolveSound(ent.Comp.SpeakSound);
        var soundPath = _audio.GetAudioPath(sound);

        // тому, кто не понимает язык говорящего, приходит абракадабра, как и в обычном чате
        var text = args.Message;
        if (args.Language is { } language && !_language.CanUnderstand(otherPhoneComponent.ConnectedPlayer.Value, language.ID))
            text = _language.ObfuscateSpeech(text, language);

        var message = Loc.GetString("phone-speak", ("name", FormattedMessage.EscapeText(speakerName)), ("message", FormattedMessage.EscapeText(text))); // LP edit

        _chatManager.ChatMessageToOne(ChatChannel.Local, message, message, otherPhoneComponent.ConnectedPlayer.Value, false, actor.PlayerSession.Channel, Color.FromHex("#9956D3"), true, soundPath, -12, hidePopup: true);
    }

    #region Helpers

    private void DoCallLogic(RotaryPhoneComponent phoneComp, Entity<RotaryPhoneComponent> ent, EntityUid phone)
    {
        if (!phoneComp.Engaged && phoneComp.ConnectedPhone is null)
        {
            ent.Comp.ConnectedPhone = phone;
            ent.Comp.SoundEntity = _audio.PlayPredicted(ent.Comp.RingingSound, ent.Owner, ent.Owner, AudioParams.Default.WithLoop(true).WithMaxDistance(2.5f))?.Entity;
            RaiseDeviceNetworkEvent(ent.Comp.ConnectedPhoneStand, ent.Comp.OutGoingPort);
            StartRingTimeout(ent); // LP edit

            var ev = new PhoneRingEvent(ent);

            RaiseLocalEvent(phone, ref ev);
        }
        else if (ent.Comp.SoundEntity is null)
        {
            ent.Comp.SoundEntity = _audio.PlayPvs(ent.Comp.BusySound, ent.Owner, AudioParams.Default.WithMaxDistance(2.5f))?.Entity;
        }
    }

    #endregion
}
