using System.Numerics;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared._LP.Reklama;

/// <summary>
/// Рекламная кнопка в лобби.
/// </summary>
[Prototype]
public sealed partial class ReklamaPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = string.Empty;

    [DataField(required: true)]
    public ResPath Icon;

    [DataField]
    public string Name = string.Empty;

    [DataField]
    public string Description = string.Empty;

    [DataField]
    public string Url = string.Empty;

    [DataField]
    public Vector2 Scale = Vector2.One;
}
