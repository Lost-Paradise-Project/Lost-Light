using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server._LP.Phones;

/// <summary>
/// На корпусе телефона (подставка дискового телефона или сам телефон) стоит жучок.
/// Добавляется при установке и не попадает в прототипы: так жучок виден только детектору.
/// </summary>
[RegisterComponent, Access(typeof(TelephoneBugSystem))]
public sealed partial class BuggedPhoneComponent : Component
{
    [DataField]
    public EntityUid? Bug;
}

/// <summary>
/// Жучок сейчас записывает. Запись выключается, когда разговор затих, чтобы кассета не тратилась зря.
/// </summary>
[RegisterComponent, AutoGenerateComponentPause, Access(typeof(TelephoneBugSystem))]
public sealed partial class BugRecordingComponent : Component
{
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan StopTime;
}
