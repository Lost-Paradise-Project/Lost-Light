using System.Numerics;
using Robust.Shared.GameStates;

namespace Content.Shared._Orion.Posing;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
public sealed partial class PosingComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public Vector2 CurrentOffset = Vector2.Zero;

    [ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public Angle CurrentAngle = Angle.Zero;

    [DataField, AutoNetworkedField]
    public Vector2 OffsetLimits = new(0.3f, 0.3f);

    [DataField, AutoNetworkedField]
    public float AngleLimits = 180f;

    [ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public bool Posing = false;

    [DataField]
    public string DefaultInputContext = "human";

    [DataField]
    public Vector2 DefaultOffset = Vector2.Zero;

    [DataField]
    public float DefaultAngle;

    // LP edit start
    /// <summary>
    /// Направление смещения и поворота от зажатых сейчас клавиш, двигает позу в Update.
    /// Сетевое, чтобы при пересчёте предсказания откатывалось к серверному, иначе нажатия копятся и позу откидывает.
    /// </summary>
    [ViewVariables, AutoNetworkedField]
    public Vector2 HeldOffset = Vector2.Zero;

    [ViewVariables, AutoNetworkedField]
    public float HeldAngle;

    /// <summary>
    /// Скорость смещения при зажатой клавише, тайлов в секунду.
    /// </summary>
    [DataField]
    public float OffsetSpeed = 0.20f;

    /// <summary>
    /// Скорость поворота при зажатой клавише, градусов в секунду.
    /// </summary>
    [DataField]
    public float AngleSpeed = 45f;
    // LP edit end
}
