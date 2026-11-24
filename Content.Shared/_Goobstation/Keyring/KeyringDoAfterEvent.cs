using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared._Goobstation.Keyring;

[Serializable, NetSerializable]
public sealed partial class KeyringDoAfterEvent : SimpleDoAfterEvent;
