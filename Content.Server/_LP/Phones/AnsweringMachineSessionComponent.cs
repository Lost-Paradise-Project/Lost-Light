using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server._LP.Phones;

/// <summary>
/// Висит на трубке звонящего, пока автоответчик слушает его сообщение.
/// </summary>
[RegisterComponent, AutoGenerateComponentPause]
public sealed partial class AnsweringMachineSessionComponent : Component
{
    public EntityUid Machine;

    public EntityUid Callee;

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan Started;

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    public TimeSpan LastSpeech;

    public int Recorded;
}
