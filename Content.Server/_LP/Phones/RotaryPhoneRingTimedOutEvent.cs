using Content.Shared._Trauma.Phones.Components;

namespace Content.Server._LP.Phones;

/// <summary>
/// Звонок на телефон дошёл до таймаута, и никто не взял трубку. Поднимается на трубке вызываемого телефона.
/// Тот, кто перехватил вызов (автоответчик), ставит <see cref="Handled"/>, и вызов не сбрасывается.
/// </summary>
[ByRefEvent]
public record struct RotaryPhoneRingTimedOutEvent(Entity<RotaryPhoneComponent> Caller)
{
    public bool Handled;
}
