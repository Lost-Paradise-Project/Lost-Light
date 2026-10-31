using Content.Server.Wires;
using Content.Shared._LP.Phones;
using Content.Shared.Wires;

namespace Content.Server._LP.Phones;

/// <summary>
/// Провод связи АТС: перерезанный обрывает все линии через эту АТС, сращённый чинит.
/// </summary>
public sealed partial class TelephoneExchangeWireAction : ComponentWireAction<TelephoneExchangeComponent>
{
    public override string Name { get; set; } = "wire-name-telephone-exchange";
    public override Color Color { get; set; } = Color.Orange;
    public override object StatusKey => TelephoneExchangeWireStatus.Line;

    public override StatusLightState? GetLightState(Wire wire, TelephoneExchangeComponent component)
    {
        return component.Sabotaged ? StatusLightState.Off : StatusLightState.On;
    }

    public override bool Cut(EntityUid user, Wire wire, TelephoneExchangeComponent component)
    {
        EntityManager.System<TelephoneExchangeSystem>().SetSabotaged((wire.Owner, component), true);
        return true;
    }

    public override bool Mend(EntityUid user, Wire wire, TelephoneExchangeComponent component)
    {
        EntityManager.System<TelephoneExchangeSystem>().SetSabotaged((wire.Owner, component), false);
        return true;
    }

    public override void Pulse(EntityUid user, Wire wire, TelephoneExchangeComponent component)
    {
    }
}
