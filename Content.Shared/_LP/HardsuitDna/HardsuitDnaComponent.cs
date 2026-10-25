using Content.Shared.Explosion;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._LP.HardsuitDna;

/// <summary>
/// Привязка скафандра к ДНК владельца. Чужой носитель получает отсчёт, после которого скафандр взрывается.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(SharedHardsuitDnaSystem))]
public sealed partial class HardsuitDnaComponent : Component
{
    [DataField, AutoNetworkedField]
    public string? Dna;

    [DataField, AutoNetworkedField]
    public bool Locked;

    [DataField]
    public TimeSpan CountdownDuration = TimeSpan.FromSeconds(5);

    [DataField]
    public float ExplosionIntensity = 1f;

    [DataField]
    public ProtoId<ExplosionPrototype> ExplosionType = "Default";

    [DataField]
    public bool GibWearer = true;

    [DataField]
    public bool AutoBindOnSpawn = true;

    [DataField]
    public SoundSpecifier BeepSound = new SoundPathSpecifier("/Audio/Effects/beep1.ogg");
}
