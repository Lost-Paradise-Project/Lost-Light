using Robust.Shared.Serialization;

namespace Content.Shared._LP.Phones;

/// <summary>
/// Диктофон, который работает автоответчиком, если вставить его в подставку дискового телефона.
/// Когда на вызов не ответили, звонящему играет приветствие, а всё, что он говорит, пишется на кассету.
/// Логика только серверная.
/// </summary>
[RegisterComponent]
public sealed partial class AnsweringMachineComponent : Component
{
    [DataField]
    public string? Greeting;

    [DataField]
    public LocId DefaultGreeting = "answering-machine-default-greeting";

    [DataField]
    public int MaxGreetingLength = 200;

    [DataField]
    public TimeSpan MaxMessageLength = TimeSpan.FromSeconds(60);

    [DataField]
    public TimeSpan SilenceTimeout = TimeSpan.FromSeconds(10);

    [ViewVariables]
    public bool NewMessages;
}

/// <summary>
/// Подставка телефона, в которую можно вставить автоответчик. Показывает индикатор новых сообщений.
/// </summary>
[RegisterComponent]
public sealed partial class AnsweringMachineStandComponent : Component;

[Serializable, NetSerializable]
public enum AnsweringMachineVisuals : byte
{
    NewMessages,
}
