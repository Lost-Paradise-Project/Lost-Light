using Content.Server._Trauma.Phones;
using Content.Server._Starlight.TapeRecorder;
using Content.Server._Starlight.TextToSpeech;
using Content.Server.Administration;
using Content.Server.Chat.Managers;
using Content.Shared._LP.Phones;
using Content.Shared._Starlight.TapeRecorder.Components;
using Content.Shared._Starlight.TextToSpeech;
using Content.Shared._Trauma.Phones.Components;
using Content.Shared.Administration.Logs;
using Content.Shared.Chat;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Database;
using Content.Shared.Examine;
using Content.Shared.Popups;
using Content.Shared.Verbs;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Containers;
using Robust.Shared.Player;
using Robust.Shared.Timing;
using Robust.Shared.Utility;

namespace Content.Server._LP.Phones;

/// <summary>
/// Автоответчик на диктофоне: если на звонок не ответили, звонящему играет приветствие,
/// а то, что он скажет, записывается на кассету диктофона. Прослушивают запись обычным воспроизведением.
/// </summary>
public sealed partial class AnsweringMachineSystem : EntitySystem
{
    public const string SlotId = "answering_machine";

    [Dependency] private ItemSlotsSystem _slots = default!;
    [Dependency] private TapeRecorderSystem _tape = default!;
    [Dependency] private RotaryPhoneSystem _rotary = default!;
    [Dependency] private TTSSystem _tts = default!;
    [Dependency] private SharedChatSystem _chat = default!;
    [Dependency] private IChatManager _chatManager = default!;
    [Dependency] private SharedAudioSystem _audio = default!;
    [Dependency] private SharedAppearanceSystem _appearance = default!;
    [Dependency] private SharedPointLightSystem _light = default!;
    [Dependency] private SharedPopupSystem _popup = default!;
    [Dependency] private SharedContainerSystem _container = default!;
    [Dependency] private QuickDialogSystem _dialog = default!;
    [Dependency] private ISharedAdminLogManager _adminLog = default!;
    [Dependency] private IGameTiming _timing = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RotaryPhoneComponent, RotaryPhoneRingTimedOutEvent>(OnRingTimedOut);
        SubscribeLocalEvent<AnsweringMachineComponent, GetVerbsEvent<AlternativeVerb>>(OnGetVerbs);
        SubscribeLocalEvent<AnsweringMachineStandComponent, EntInsertedIntoContainerMessage>(OnInserted);
        SubscribeLocalEvent<AnsweringMachineStandComponent, EntRemovedFromContainerMessage>(OnRemoved);
        SubscribeLocalEvent<AnsweringMachineStandComponent, ExaminedEvent>(OnExamineHolder);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<AnsweringMachineSessionComponent, RotaryPhoneComponent>();
        while (query.MoveNext(out var uid, out var session, out var phone))
        {
            if (!TryGetMachine(session.Machine, out _, out var recorder))
            {
                Finish((uid, phone), session, false);
                continue;
            }

            // Звонящий положил трубку или кто-то взял трубку вызываемого: запись просто закрываем
            if (phone.ConnectedPhone != session.Callee
                || !TryComp<RotaryPhoneComponent>(session.Callee, out var callee)
                || callee.Connected)
            {
                Finish((uid, phone), session, false);
                continue;
            }

            var machine = Comp<AnsweringMachineComponent>(session.Machine);
            var now = _timing.CurTime;
            if (recorder.Comp.Mode != TapeRecorderMode.Recording
                || now - session.Started >= machine.MaxMessageLength
                || now - session.LastSpeech >= machine.SilenceTimeout)
            {
                Finish((uid, phone), session, true);
            }
        }
    }

    #region Calls

    private void OnRingTimedOut(Entity<RotaryPhoneComponent> callee, ref RotaryPhoneRingTimedOutEvent args)
    {
        if (args.Handled
            || callee.Comp.ConnectedPhoneStand is not { } stand
            || _slots.GetItemOrNull(stand, SlotId) is not { } machineUid
            || !TryGetMachine(machineUid, out var machine, out var recorder)
            || !_tape.TryStartRecording(recorder))
            return;

        var caller = args.Caller;
        args.Handled = true;

        _rotary.StopRinging(callee);
        caller.Comp.SoundEntity = _audio.Stop(caller.Comp.SoundEntity);

        var session = EnsureComp<AnsweringMachineSessionComponent>(caller);
        session.Machine = machineUid;
        session.Callee = callee;
        session.Started = _timing.CurTime;
        session.LastSpeech = _timing.CurTime;
        session.Recorded = 0;

        PlayGreeting(caller, machine);
    }

    /// <summary>
    /// Приветствие слышит только звонящий: текстом в чате и озвучкой в трубке.
    /// </summary>
    private void PlayGreeting(Entity<RotaryPhoneComponent> caller, Entity<AnsweringMachineComponent> machine)
    {
        if (caller.Comp.ConnectedPlayer is not { } player || !TryComp<ActorComponent>(player, out var actor))
            return;

        var greeting = machine.Comp.Greeting ?? Loc.GetString(machine.Comp.DefaultGreeting);
        var message = Loc.GetString("phone-speak",
            ("name", Loc.GetString("answering-machine-name")),
            ("message", FormattedMessage.EscapeText(greeting)));

        _chatManager.ChatMessageToOne(ChatChannel.Local, message, message, player, false, actor.PlayerSession.Channel, Color.FromHex("#9956D3"), true, hidePopup: true);

        EnsureComp<TextToSpeechComponent>(machine);
        _tts.PlayPrivateSpeech(player, machine, greeting, TTSEffect.Phone);
    }

    /// <summary>
    /// Реплика звонящего. Возвращает true, если её забрал автоответчик и до вызываемого телефона она не дойдёт.
    /// </summary>
    public bool TryRecord(Entity<RotaryPhoneComponent> caller, EntityUid source, string name, string message)
    {
        if (!TryComp<AnsweringMachineSessionComponent>(caller, out var session))
            return false;

        if (!TryGetMachine(session.Machine, out _, out var recorder))
            return true;

        var verb = _chat.GetSpeechVerb(source, message).ID;
        var voice = _tts.ResolveSpeakerVoiceId(source);

        if (_tape.TryRecordMessage(recorder, name, verb, message, voice?.Id))
        {
            session.Recorded++;
            session.LastSpeech = _timing.CurTime;
        }

        return true;
    }

    private void Finish(Entity<RotaryPhoneComponent> caller, AnsweringMachineSessionComponent session, bool hangUp)
    {
        RemCompDeferred<AnsweringMachineSessionComponent>(caller);

        if (TryGetMachine(session.Machine, out var machine, out var recorder))
        {
            _tape.StopRecording(recorder);

            if (session.Recorded > 0)
                SetNewMessages(machine, true);
        }

        if (hangUp)
            _rotary.DropCall(caller, session.Recorded > 0 ? "answering-machine-popup-saved" : "phone-popup-no-answer");
    }

    #endregion

    #region Indicator

    private void SetNewMessages(Entity<AnsweringMachineComponent> machine, bool value)
    {
        machine.Comp.NewMessages = value;

        if (_container.TryGetContainingContainer(machine.Owner, out var container))
            UpdateIndicator(container.Owner, value);
    }

    private void UpdateIndicator(EntityUid stand, bool value)
    {
        if (!HasComp<AnsweringMachineStandComponent>(stand))
            return;

        _appearance.SetData(stand, AnsweringMachineVisuals.NewMessages, value);

        if (_light.TryGetLight(stand, out var light))
            _light.SetEnabled(stand, value, light);
    }

    private void OnInserted(Entity<AnsweringMachineStandComponent> stand, ref EntInsertedIntoContainerMessage args)
    {
        if (args.Container.ID == SlotId && TryComp<AnsweringMachineComponent>(args.Entity, out var machine))
            UpdateIndicator(stand, machine.NewMessages);
    }

    /// <summary>
    /// Диктофон вынули послушать: сообщения считаются просмотренными.
    /// </summary>
    private void OnRemoved(Entity<AnsweringMachineStandComponent> stand, ref EntRemovedFromContainerMessage args)
    {
        if (args.Container.ID != SlotId || !TryComp<AnsweringMachineComponent>(args.Entity, out var machine))
            return;

        machine.NewMessages = false;
        UpdateIndicator(stand, false);
    }

    private void OnExamineHolder(Entity<AnsweringMachineStandComponent> stand, ref ExaminedEvent args)
    {
        if (_slots.GetItemOrNull(stand, SlotId) is { } machine
            && TryComp<AnsweringMachineComponent>(machine, out var comp)
            && comp.NewMessages)
        {
            args.PushMarkup(Loc.GetString("answering-machine-examine-new-messages"));
        }
    }

    #endregion

    #region Greeting

    private void OnGetVerbs(Entity<AnsweringMachineComponent> machine, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanComplexInteract
            || !args.CanAccess
            || !args.CanInteract
            || !TryComp<ActorComponent>(args.User, out var actor))
            return;

        var user = args.User;
        var session = actor.PlayerSession;

        args.Verbs.Add(new AlternativeVerb
        {
            Text = Loc.GetString("answering-machine-verb-greeting"),
            Act = () => _dialog.OpenDialog(session,
                Loc.GetString("answering-machine-greeting-title"),
                Loc.GetString("answering-machine-greeting-prompt", ("max", machine.Comp.MaxGreetingLength)),
                (string text) => SetGreeting(machine, user, text)),
        });
    }

    private void SetGreeting(Entity<AnsweringMachineComponent> machine, EntityUid user, string text)
    {
        text = text.Trim();

        if (text.Length > machine.Comp.MaxGreetingLength)
        {
            _popup.PopupEntity(Loc.GetString("answering-machine-greeting-too-long"), machine, user);
            return;
        }

        // Пустой текст возвращает стандартное приветствие
        machine.Comp.Greeting = text.Length == 0 ? null : text;
        _adminLog.Add(LogType.Action, LogImpact.Low, $"{ToPrettyString(user):player} set the greeting of {ToPrettyString(machine):machine}: {machine.Comp.Greeting ?? "default"}");
        _popup.PopupEntity(Loc.GetString("answering-machine-greeting-saved"), machine, user);
    }

    #endregion

    private bool TryGetMachine(EntityUid uid, out Entity<AnsweringMachineComponent> machine, out Entity<TapeRecorderComponent> recorder)
    {
        machine = default;
        recorder = default;

        if (Deleted(uid) || !TryComp<AnsweringMachineComponent>(uid, out var machineComp) || !TryComp<TapeRecorderComponent>(uid, out var recorderComp))
            return false;

        machine = (uid, machineComp);
        recorder = (uid, recorderComp);
        return true;
    }
}
