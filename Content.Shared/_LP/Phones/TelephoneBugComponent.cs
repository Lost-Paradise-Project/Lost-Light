using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared._LP.Phones;

/// <summary>
/// Жучок для телефона: ставится на телефон, прячется внутри и пишет разговоры на свою встроенную кассету.
/// Сам предмет - диктофон (<c>TapeRecorder</c>), так что запись слушают обычным воспроизведением, когда жучок достали.
/// </summary>
[RegisterComponent]
public sealed partial class TelephoneBugComponent : Component
{
    [DataField]
    public TimeSpan InstallTime = TimeSpan.FromSeconds(4);
}

/// <summary>
/// Ручной детектор жучков: пищит чаще, чем ближе телефон с жучком.
/// </summary>
[RegisterComponent]
public sealed partial class TelephoneBugDetectorComponent : Component
{
    [DataField]
    public float Range = 6f;
}

[Serializable, NetSerializable]
public sealed partial class TelephoneBugInstallDoAfterEvent : SimpleDoAfterEvent;

/// <summary>
/// Полный разбор телефона отвёрткой: показывает, есть ли внутри жучок, и достаёт его.
/// </summary>
[Serializable, NetSerializable]
public sealed partial class TelephoneDisassembleDoAfterEvent : SimpleDoAfterEvent;
