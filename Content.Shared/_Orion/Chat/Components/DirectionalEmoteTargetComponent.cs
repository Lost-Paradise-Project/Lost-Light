using Robust.Shared.Serialization;

namespace Content.Shared._Orion.Chat.Components;

/// <summary>
///     Marks an entity that can send and receive directional emotes.
/// </summary>
[RegisterComponent]
public sealed partial class DirectionalEmoteTargetComponent : Component
{
    public TimeSpan LastSend = TimeSpan.MinValue;

    [DataField]
    public TimeSpan Cooldown = TimeSpan.FromSeconds(1);
}

[Serializable, NetSerializable]
public sealed class SendDirectionalEmoteEvent(NetEntity source, NetEntity target, string text) : EntityEventArgs
{
    public readonly NetEntity Source = source;
    public readonly NetEntity Target = target;
    public readonly string Text = text;
}
