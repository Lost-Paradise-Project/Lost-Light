using Content.Server._LP.Phones;

namespace Content.Server._Trauma.Phones;

/// <summary>
/// Подслушивание дискового телефона жучком.
/// </summary>
public sealed partial class RotaryPhoneSystem
{
    [Dependency] private TelephoneBugSystem _bug = default!;
}
