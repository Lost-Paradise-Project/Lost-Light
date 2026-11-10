using Content.Server.Chat.Managers;
using Content.Server.Chat.Systems;
using Content.Server.Explosion.EntitySystems;
using Content.Shared._LP.HardsuitDna;
using Content.Shared.Chat;
using Content.Shared.Database;
using Content.Shared.Forensics;
using Content.Shared.Forensics.Components;
using Content.Shared.GameTicking;
using Content.Shared.Gibbing;
using Content.Shared.Inventory;
using Content.Shared.Inventory.Events;
using Content.Shared.Mobs.Systems;
using Content.Shared.Popups;
using Robust.Server.Audio;
using Robust.Shared.Player;
using Robust.Shared.Timing;

namespace Content.Server._LP.HardsuitDna;

/// <summary>
/// Привязка к ДНК: привязывает скафандр к владельцу и ведёт отсчёт до взрыва, если надел чужой.
/// </summary>
public sealed partial class HardsuitDnaSystem : SharedHardsuitDnaSystem
{
    [Dependency] private IChatManager _chatManager = default!;
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private AudioSystem _audio = default!;
    [Dependency] private ChatSystem _chat = default!;
    [Dependency] private ExplosionSystem _explosion = default!;
    [Dependency] private GibbingSystem _gibbing = default!;
    [Dependency] private InventorySystem _inventory = default!;
    [Dependency] private MobStateSystem _mobState = default!;

    private const float ExplosionBaseIntensity = 4f;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<HardsuitDnaComponent, GotEquippedEvent>(OnGotEquipped);
        SubscribeLocalEvent<HardsuitDnaComponent, GotUnequippedEvent>(OnGotUnequipped);
        SubscribeLocalEvent<PlayerSpawnCompleteEvent>(OnPlayerSpawnComplete);
        SubscribeLocalEvent<DnaComponent, GenerateDnaEvent>(OnDnaGenerated);
    }

    private void OnGotEquipped(Entity<HardsuitDnaComponent> ent, ref GotEquippedEvent args)
    {
        if (TerminatingOrDeleted(args.EquipTarget))
            return;

        var wearer = args.EquipTarget;
        var wearerDna = CompOrNull<DnaComponent>(wearer)?.DNA;

        if (ent.Comp.Dna == null)
        {
            // Без ДНК у носителя привязывать не к чему: скафандр остаётся свободным
            if (wearerDna != null)
                Bind(ent, wearer, wearerDna);
            return;
        }

        // Носитель без ДНК (борг, ИИ и т.п.) считается чужим
        if (wearerDna == ent.Comp.Dna)
            return;

        StartCountdown(ent, wearer);
    }

    private void OnGotUnequipped(Entity<HardsuitDnaComponent> ent, ref GotUnequippedEvent args) => CancelCountdown(ent.Owner, args.EquipTarget);

    private void OnPlayerSpawnComplete(PlayerSpawnCompleteEvent args) => BindCarriedSuits(args.Mob);

    // Снаряжение могут выдать до того, как у моба появится ДНК (она создаётся при MapInit)
    private void OnDnaGenerated(Entity<DnaComponent> ent, ref GenerateDnaEvent args) => BindCarriedSuits(ent.Owner);

    // Скафандры, выданные персонажу при спавне, привязываются к нему сразу
    private void BindCarriedSuits(EntityUid mob)
    {
        if (CompOrNull<DnaComponent>(mob)?.DNA is not { } dna)
            return;

        foreach (var item in _inventory.GetHandOrInventoryEntities(mob))
        {
            if (!TryComp<HardsuitDnaComponent>(item, out var suit) || !suit.AutoBindOnSpawn || suit.Dna != null)
                continue;

            Bind((item, suit), mob, dna);
        }
    }

    private void Bind(Entity<HardsuitDnaComponent> ent, EntityUid owner, string dna)
    {
        ent.Comp.Dna = dna;
        Dirty(ent);

        Popup.PopupEntity(Loc.GetString("hardsuit-dna-popup-bound"), ent, owner);
        AdminLog.Add(LogType.Action, LogImpact.Low,
            $"{ToPrettyString(ent):hardsuit} was bound to the DNA of {ToPrettyString(owner):owner}");
    }

    private void StartCountdown(Entity<HardsuitDnaComponent> ent, EntityUid wearer)
    {
        var seconds = (int) Math.Ceiling(ent.Comp.CountdownDuration.TotalSeconds);

        var countdown = EnsureComp<HardsuitDnaCountdownComponent>(ent);
        countdown.Wearer = wearer;
        countdown.EndTime = _timing.CurTime + ent.Comp.CountdownDuration;
        countdown.NextAnnounce = seconds;

        Popup.PopupEntity(Loc.GetString("hardsuit-dna-popup-mismatch"), wearer, wearer, PopupType.LargeCaution);
        if (TryComp<ActorComponent>(wearer, out var actor))
            _chatManager.DispatchServerMessage(actor.PlayerSession, Loc.GetString("hardsuit-dna-chat-mismatch", ("seconds", seconds)));

        AdminLog.Add(LogType.Action, LogImpact.High,
            $"{ToPrettyString(wearer):wearer} put on {ToPrettyString(ent):hardsuit} bound to another DNA, self-destruct in {seconds} s");
    }

    private void CancelCountdown(EntityUid suit, EntityUid wearer)
    {
        if (!RemComp<HardsuitDnaCountdownComponent>(suit) || TerminatingOrDeleted(wearer))
            return;

        Popup.PopupEntity(Loc.GetString("hardsuit-dna-popup-cancelled"), wearer, wearer);
        AdminLog.Add(LogType.Action, LogImpact.Medium,
            $"{ToPrettyString(wearer):wearer} took off {ToPrettyString(suit):hardsuit}, self-destruct cancelled");
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;
        var query = EntityQueryEnumerator<HardsuitDnaCountdownComponent, HardsuitDnaComponent>();
        while (query.MoveNext(out var uid, out var countdown, out var suit))
        {
            if (!IsWornBy(uid, countdown.Wearer))
            {
                RemComp<HardsuitDnaCountdownComponent>(uid);
                continue;
            }

            var left = countdown.EndTime - now;
            if (left <= -suit.FinalDelay)
            {
                Detonate((uid, suit), countdown.Wearer);
                continue;
            }

            if (countdown.NextAnnounce > 0 && left <= TimeSpan.FromSeconds(countdown.NextAnnounce))
            {
                // Длинную первую фразу не перебиваем цифрами: считаем вслух только последние секунды
                var first = countdown.NextAnnounce == (int) Math.Ceiling(suit.CountdownDuration.TotalSeconds);
                if (first || countdown.NextAnnounce <= suit.CountVoiceFrom)
                    Announce((uid, suit), countdown.NextAnnounce, first);

                countdown.NextAnnounce--;
            }
        }
    }

    /// <summary>
    /// Скафандр всё ещё надет на этого живого носителя. Умерший или удалённый носитель отменяет отсчёт.
    /// </summary>
    private bool IsWornBy(EntityUid suit, EntityUid wearer) => !TerminatingOrDeleted(wearer)
                && !_mobState.IsDead(wearer)
                && Transform(suit).ParentUid == wearer
                && _inventory.TryGetContainingSlot(suit, out _);

    private void Announce(Entity<HardsuitDnaComponent> ent, int seconds, bool first)
    {
        _audio.PlayPvs(ent.Comp.BeepSound, ent);
        _chat.TrySendInGameICMessage(ent,
            Loc.GetString(first ? "hardsuit-dna-voice-start" : "hardsuit-dna-voice-tick", ("seconds", seconds)),
            InGameICChatType.Speak,
            hideChat: false,
            ignoreActionBlocker: true);
    }

    private void Detonate(Entity<HardsuitDnaComponent> ent, EntityUid wearer)
    {
        RemComp<HardsuitDnaCountdownComponent>(ent);

        AdminLog.Add(LogType.Gib, LogImpact.Extreme,
            $"{ToPrettyString(ent):hardsuit} self-destructed on {ToPrettyString(wearer):wearer} (gib: {ent.Comp.GibWearer})");

        // Взрыв ставится первым, пока скафандр ещё на носителе: точка берётся с его позиции
        var intensity = ExplosionBaseIntensity * ent.Comp.ExplosionIntensity;
        _explosion.QueueExplosion(ent, ent.Comp.ExplosionType, intensity, 1f, intensity, maxTileBreak: 0, canCreateVacuum: false);

        if (ent.Comp.GibWearer)
            _gibbing.Gib(wearer);

        QueueDel(ent);
    }
}
