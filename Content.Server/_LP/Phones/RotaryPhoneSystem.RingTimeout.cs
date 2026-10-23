using Content.Server._LP.Phones;
using Content.Shared._Trauma.Phones.Components;
using Content.Shared.Popups;
using Robust.Shared.Audio;
using Robust.Shared.Timing;

namespace Content.Server._Trauma.Phones;

/// <summary>
/// Таймаут звонка: если на исходящий вызов не ответили за <see cref="RotaryPhoneComponent.RingTimeout"/>,
/// вызов сбрасывается у обоих телефонов, а звонящему сообщают, что никто не ответил.
/// </summary>
public sealed partial class RotaryPhoneSystem
{
    [Dependency] private IGameTiming _timing = default!;
    [Dependency] private TelephoneExchangeSystem _exchange = default!;

    private bool IsLineWorking(Entity<RotaryPhoneComponent> caller, EntityUid receiver, RotaryPhoneComponent receiverPhone)
    {
        return _exchange.CanConnect(caller, caller.Comp.RequiresExchange, receiver, receiverPhone.RequiresExchange);
    }

    private void InitializeRingTimeout()
    {
        SubscribeLocalEvent<RotaryPhoneComponent, ComponentShutdown>(OnPhoneShutdown);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<RotaryPhoneCallingComponent, RotaryPhoneComponent>();
        while (query.MoveNext(out var uid, out var calling, out var phone))
        {
            // Вызов уже принят, сброшен или перенаправлен - таймер больше не нужен
            if (phone.Connected
                || phone.ConnectedPhone is not { } callee
                || !TryComp<RotaryPhoneComponent>(callee, out var calleePhone)
                || calleePhone.Connected
                || calleePhone.ConnectedPhone != uid)
            {
                RemCompDeferred<RotaryPhoneCallingComponent>(uid);
                continue;
            }

            if (_timing.CurTime < calling.EndTime)
                continue;

            RemCompDeferred<RotaryPhoneCallingComponent>(uid);

            // Автоответчик может принять вызов вместо сброса
            var timedOut = new RotaryPhoneRingTimedOutEvent((uid, phone));
            RaiseLocalEvent(callee, ref timedOut);
            if (timedOut.Handled)
                continue;

            EndUnansweredCall((uid, phone), callee, calleePhone);
        }
    }

    /// <summary>
    /// Запускает таймер сброса для только что начатого вызова.
    /// </summary>
    private void StartRingTimeout(Entity<RotaryPhoneComponent> caller)
    {
        var calling = EnsureComp<RotaryPhoneCallingComponent>(caller);
        calling.EndTime = _timing.CurTime + caller.Comp.RingTimeout;
    }

    private void EndUnansweredCall(Entity<RotaryPhoneComponent> caller, EntityUid callee, RotaryPhoneComponent calleePhone)
    {
        DropCall(caller, "phone-popup-no-answer");
        Dirty(callee, calleePhone);
    }

    /// <summary>
    /// Сбрасывает вызов или разговор телефона, не трогая трубку: она остаётся у держащего и считается снятой.
    /// Собеседник слышит отбой, держащему показывается причина.
    /// </summary>
    public void DropCall(Entity<RotaryPhoneComponent> phone, LocId reason)
    {
        // DisconnectPhones сбрасывает Engaged, а трубка всё ещё в руках
        var engaged = phone.Comp.Engaged;
        DisconnectPhones(phone.Comp);
        phone.Comp.Engaged = engaged;

        phone.Comp.SoundEntity = _audio.PlayPvs(phone.Comp.HandUpSoundLocal, phone.Owner, AudioParams.Default.WithMaxDistance(2.5f))?.Entity;

        PopupToHolder(phone, reason);
        Dirty(phone);
    }

    /// <summary>
    /// Звонить некуда: линия не отвечает (нет АТС, нет питания или связь оборвана саботажем).
    /// </summary>
    private void RefuseCall(Entity<RotaryPhoneComponent> phone)
    {
        phone.Comp.SoundEntity ??= _audio.PlayPvs(phone.Comp.BusySound, phone.Owner, AudioParams.Default.WithMaxDistance(2.5f))?.Entity;
        PopupToHolder(phone, "phone-popup-line-down");
    }

    private void PopupToHolder(Entity<RotaryPhoneComponent> phone, LocId message)
    {
        var text = Loc.GetString(message);
        if (phone.Comp.ConnectedPlayer is { } player)
            _popup.PopupEntity(text, phone.Owner, player, PopupType.Small);
        else
            _popup.PopupEntity(text, phone.Owner, PopupType.Small);
    }

    /// <summary>
    /// Телефон удалили посреди вызова: второй телефон не должен остаться звонить или висеть на несуществующем собеседнике.
    /// </summary>
    private void OnPhoneShutdown(Entity<RotaryPhoneComponent> ent, ref ComponentShutdown args)
    {
        if (ent.Comp.ConnectedPhone is not { } other
            || TerminatingOrDeleted(other)
            || !TryComp<RotaryPhoneComponent>(other, out var otherPhone)
            || otherPhone.ConnectedPhone != ent.Owner)
            return;

        var wasConnected = otherPhone.Connected;

        otherPhone.SoundEntity = _audio.Stop(otherPhone.SoundEntity);
        otherPhone.ConnectedPhone = null;
        otherPhone.Connected = false;

        if (wasConnected)
            otherPhone.SoundEntity = _audio.PlayPvs(otherPhone.HandUpSoundLocal, other, AudioParams.Default.WithMaxDistance(2.5f))?.Entity;
        else if (!otherPhone.Engaged && otherPhone.ConnectedPhoneStand is { } stand)
            UpdateAppearance(stand, RotaryPhoneVisuals.Base);

        Dirty(other, otherPhone);
    }
}
