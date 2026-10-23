using System.Diagnostics.CodeAnalysis;
using Content.Server._Starlight.TapeRecorder;
using Content.Server._Starlight.TextToSpeech;
using Content.Shared._LP.Phones;
using Content.Shared._Starlight.TapeRecorder.Components;
using Content.Shared._Trauma.Phones.Components;
using Content.Shared.Administration.Logs;
using Content.Shared.Chat;
using Content.Shared.Database;
using Content.Shared.DoAfter;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Popups;
using Content.Shared.Telephone;
using Content.Shared.Tools;
using Content.Shared.Tools.Systems;
using Content.Shared.Verbs;
using Robust.Shared.Containers;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;

namespace Content.Server._LP.Phones;

/// <summary>
/// Жучок на телефонной линии: всё, что говорят в разговоре через телефон, дублируется на кассету жучка.
/// Имя и голос записываются так, как их слышит собеседник (с учётом голосовой маски).
/// </summary>
public sealed partial class TelephoneBugSystem : EntitySystem
{
    private static readonly ProtoId<ToolQualityPrototype> ScrewingQuality = "Screwing";
    private const string ContainerId = "lp_telephone_bug";

    private static readonly TimeSpan IdleStop = TimeSpan.FromSeconds(5);

    private static readonly TimeSpan DisassembleTime = TimeSpan.FromSeconds(6);

    [Dependency] private SharedDoAfterSystem _doAfter = default!;
    [Dependency] private SharedContainerSystem _container = default!;
    [Dependency] private SharedHandsSystem _hands = default!;
    [Dependency] private SharedToolSystem _tool = default!;
    [Dependency] private SharedPopupSystem _popup = default!;
    [Dependency] private SharedChatSystem _chat = default!;
    [Dependency] private ISharedAdminLogManager _adminLog = default!;
    [Dependency] private TapeRecorderSystem _tape = default!;
    [Dependency] private TTSSystem _tts = default!;
    [Dependency] private IGameTiming _timing = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TelephoneBugComponent, AfterInteractEvent>(OnBugAfterInteract);
        SubscribeLocalEvent<TelephoneBugComponent, TelephoneBugInstallDoAfterEvent>(OnInstalled);

        SubscribeLocalEvent<RotaryPhoneHolderComponent, GetVerbsEvent<AlternativeVerb>>(OnGetVerbsHolder);
        SubscribeLocalEvent<TelephoneComponent, GetVerbsEvent<AlternativeVerb>>(OnGetVerbsTelephone);
        SubscribeLocalEvent<RotaryPhoneHolderComponent, TelephoneDisassembleDoAfterEvent>(OnDisassembled);
        SubscribeLocalEvent<TelephoneComponent, TelephoneDisassembleDoAfterEvent>(OnDisassembled);

        SubscribeLocalEvent<TelephoneComponent, TelephoneMessageSentEvent>(OnTelephoneSent);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<BugRecordingComponent, BuggedPhoneComponent>();
        while (query.MoveNext(out var uid, out var recording, out var bugged))
        {
            if (_timing.CurTime < recording.StopTime)
                continue;

            if (bugged.Bug is { } bug && TryComp<TapeRecorderComponent>(bug, out var recorder))
                _tape.StopRecording((bug, recorder));

            RemCompDeferred<BugRecordingComponent>(uid);
        }
    }

    #region Housing

    /// <summary>
    /// Корпус, на который ставят жучок: у дискового телефона это подставка (трубка уходит со снятием),
    /// у обычного телефона - он сам.
    /// </summary>
    private bool TryGetHousing(EntityUid phone, out EntityUid housing)
    {
        housing = default;

        if (HasComp<RotaryPhoneHolderComponent>(phone) || HasComp<TelephoneComponent>(phone))
        {
            housing = phone;
            return true;
        }

        if (TryComp<RotaryPhoneComponent>(phone, out var handset) && handset.ConnectedPhoneStand is { } stand)
        {
            housing = stand;
            return true;
        }

        return false;
    }

    #endregion

    #region Install

    private void OnBugAfterInteract(Entity<TelephoneBugComponent> bug, ref AfterInteractEvent args)
    {
        if (args.Handled || !args.CanReach || args.Target is not { } target || !TryGetHousing(target, out var housing))
            return;

        args.Handled = true;

        if (HasComp<BuggedPhoneComponent>(housing))
        {
            _popup.PopupEntity(Loc.GetString("telephone-bug-already-installed"), housing, args.User);
            return;
        }

        var doAfter = new DoAfterArgs(EntityManager, args.User, bug.Comp.InstallTime, new TelephoneBugInstallDoAfterEvent(), bug, housing, bug)
        {
            BreakOnMove = true,
            NeedHand = true,
        };
        _doAfter.TryStartDoAfter(doAfter);
    }

    private void OnInstalled(Entity<TelephoneBugComponent> bug, ref TelephoneBugInstallDoAfterEvent args)
    {
        if (args.Handled || args.Cancelled || args.Target is not { } housing)
            return;

        args.Handled = TryInstall(bug, housing, args.User);
    }

    /// <summary>
    /// Прячет жучок внутри корпуса телефона. На один телефон - один жучок.
    /// </summary>
    public bool TryInstall(Entity<TelephoneBugComponent> bug, EntityUid housing, EntityUid user)
    {
        if (HasComp<BuggedPhoneComponent>(housing))
            return false;

        var container = _container.EnsureContainer<ContainerSlot>(housing, ContainerId);
        if (!_container.Insert(bug.Owner, container))
            return false;

        var bugged = EnsureComp<BuggedPhoneComponent>(housing);
        bugged.Bug = bug;

        _adminLog.Add(LogType.Action, LogImpact.Medium, $"{ToPrettyString(user):player} installed a telephone bug {ToPrettyString(bug):bug} on {ToPrettyString(housing):phone}");
        _popup.PopupEntity(Loc.GetString("telephone-bug-installed"), housing, user);
        return true;
    }

    #endregion

    #region Disassemble

    private void OnGetVerbsHolder(Entity<RotaryPhoneHolderComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        AddDisassembleVerb(ent, ref args);
    }

    private void OnGetVerbsTelephone(Entity<TelephoneComponent> ent, ref GetVerbsEvent<AlternativeVerb> args)
    {
        AddDisassembleVerb(ent, ref args);
    }

    /// <summary>
    /// Глагол «Разобрать» есть у любого телефона, если в руке отвёртка, - не только у того, где жучок,
    /// иначе сам глагол выдавал бы его.
    /// </summary>
    private void AddDisassembleVerb(EntityUid phone, ref GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanComplexInteract
            || !args.CanAccess
            || !args.CanInteract
            || args.Using is not { } tool
            || !_tool.HasQuality(tool, ScrewingQuality)
            || !TryGetHousing(phone, out var housing))
            return;

        var user = args.User;
        args.Verbs.Add(new AlternativeVerb
        {
            Text = Loc.GetString("telephone-bug-disassemble"),
            Act = () => _doAfter.TryStartDoAfter(new DoAfterArgs(EntityManager, user, DisassembleTime, new TelephoneDisassembleDoAfterEvent(), phone, housing, tool)
            {
                BreakOnMove = true,
                NeedHand = true,
            }),
        });
    }

    private void OnDisassembled(Entity<RotaryPhoneHolderComponent> ent, ref TelephoneDisassembleDoAfterEvent args)
    {
        Disassemble(ent, ref args);
    }

    private void OnDisassembled(Entity<TelephoneComponent> ent, ref TelephoneDisassembleDoAfterEvent args)
    {
        Disassemble(ent, ref args);
    }

    private void Disassemble(EntityUid phone, ref TelephoneDisassembleDoAfterEvent args)
    {
        if (args.Handled || args.Cancelled || args.Target is not { } housing)
            return;

        args.Handled = true;

        if (!TryRemove(housing, args.User))
            _popup.PopupEntity(Loc.GetString("telephone-bug-disassemble-clean"), housing, args.User);
    }

    /// <summary>
    /// Достаёт жучок из корпуса в руки того, кто разбирал телефон. Ложь, если жучка не было.
    /// </summary>
    public bool TryRemove(EntityUid housing, EntityUid user)
    {
        if (!TryComp<BuggedPhoneComponent>(housing, out var bugged) || bugged.Bug is not { } bug)
            return false;

        if (TryComp<TapeRecorderComponent>(bug, out var recorder))
            _tape.StopRecording((bug, recorder));

        _container.TryRemoveFromContainer(bug);
        RemComp<BuggedPhoneComponent>(housing);
        RemComp<BugRecordingComponent>(housing);
        _hands.PickupOrDrop(user, bug);

        _adminLog.Add(LogType.Action, LogImpact.Medium, $"{ToPrettyString(user):player} found and removed a telephone bug {ToPrettyString(bug):bug} from {ToPrettyString(housing):phone}");
        _popup.PopupEntity(Loc.GetString("telephone-bug-disassemble-found"), housing, user, PopupType.MediumCaution);
        return true;
    }

    #endregion

    #region Recording

    private void OnTelephoneSent(Entity<TelephoneComponent> ent, ref TelephoneMessageSentEvent args)
    {
        Record(ent, args.MessageSource, args.Message);
    }

    /// <summary>
    /// Реплика пришла на обычный телефон от собеседника (вызывает TelephoneSystem).
    /// </summary>
    public void RecordTelephone(EntityUid telephone, EntityUid source, string message)
    {
        Record(telephone, source, message);
    }

    /// <summary>
    /// Реплика прошла через трубку дискового телефона: и сказанная в неё, и услышанная из неё.
    /// </summary>
    public void RecordRotary(EntityUid handset, EntityUid source, string message)
    {
        if (TryComp<RotaryPhoneComponent>(handset, out var phone) && phone.ConnectedPhoneStand is { } stand)
            Record(stand, source, message);
    }

    private void Record(EntityUid housing, EntityUid source, string message)
    {
        if (!TryGetBug(housing, out var recorder) || !_tape.TryStartRecording(recorder))
            return;

        // Имя и голос такие же, как слышит собеседник: маска голоса подменяет и то и другое
        var nameEv = new TransformSpeakerNameEvent(source, Name(source));
        RaiseLocalEvent(source, nameEv);

        var verb = nameEv.SpeechVerb ?? _chat.GetSpeechVerb(source, message).ID;
        _tape.TryRecordMessage(recorder, nameEv.VoiceName, verb, message, _tts.ResolveSpeakerVoiceId(source)?.Id);

        EnsureComp<BugRecordingComponent>(housing).StopTime = _timing.CurTime + IdleStop;
    }

    private bool TryGetBug(EntityUid housing, [NotNullWhen(true)] out Entity<TapeRecorderComponent> recorder)
    {
        recorder = default;

        if (!TryComp<BuggedPhoneComponent>(housing, out var bugged)
            || bugged.Bug is not { } bug
            || !TryComp<TapeRecorderComponent>(bug, out var comp))
            return false;

        recorder = (bug, comp);
        return true;
    }

    #endregion
}
