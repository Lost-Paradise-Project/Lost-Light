namespace Content.Shared._LP.Holiday;

/// <summary>
/// Отметка на сущности, созданной маркером праздника (<see cref="HolidaySpawnerMarkerComponent"/>).
/// </summary>
[RegisterComponent]
public sealed partial class HolidayEffectComponent : Component
{
    [DataField]
    public string Holiday = string.Empty;
}
