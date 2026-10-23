using Robust.Shared.GameStates;
using Robust.Shared.Utility;

namespace Content.Shared._Trauma.Phones.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class RotaryPhoneHolderComponent : Component
{
    [DataField, AutoNetworkedField]
    public int? PhoneNumber;

    [DataField, AutoNetworkedField]
    public EntityUid? ConnectedPhone;

    [DataField]
    public string? Name; // LP edit

    [DataField]
    public SpriteSpecifier RopeSprite = new SpriteSpecifier.Rsi(new ResPath("_RMC14/Objects/phone/phone.rsi"), "rope");
}
