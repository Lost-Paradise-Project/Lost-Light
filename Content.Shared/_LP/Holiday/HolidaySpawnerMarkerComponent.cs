using Robust.Shared.Prototypes;

namespace Content.Shared._LP.Holiday;

/// <summary>
/// Маркер, который ставят мапперы. На старте раунда (или по команде holidayeffects_spawn),
/// если идёт нужный праздник, на месте маркера создаётся <see cref="Spawn"/>.
/// </summary>
/// <remarks>
/// Прототип праздника лежит в Content.Server, поэтому здесь id строкой; существование id проверяет система и тест.
/// </remarks>
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
