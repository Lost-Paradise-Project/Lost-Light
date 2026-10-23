using Robust.Shared.Prototypes;

namespace Content.Shared._LP.Holiday;

[RegisterComponent]
public sealed partial class HolidaySpawnerMarkerComponent : Component
{
    [DataField]
    public string Holiday = string.Empty;

    [DataField]
    public List<string> ExtraHolidays = new();

    [DataField]
    public EntProtoId? Spawn;

    [DataField]
    public float Chance = 1f;

    [ViewVariables]
    public EntityUid? Spawned;
}
