using Robust.Shared.GameStates;

namespace Content.Shared._Trauma.PullBlocker;

/// <summary>
/// This stops entities from pulling the entity this component is attached to
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class BlockPullComponent : Component;
