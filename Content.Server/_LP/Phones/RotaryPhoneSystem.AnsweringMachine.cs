using Content.Server._LP.Phones;
using Content.Shared._Trauma.Phones.Components;

namespace Content.Server._Trauma.Phones;

/// <summary>
/// Связка дискового телефона с автоответчиком: автоответчик снимает трубку виртуально и слушает звонящего.
/// </summary>
public sealed partial class RotaryPhoneSystem
{
    [Dependency] private AnsweringMachineSystem _answering = default!;

    /// <summary>
    /// Вызываемый телефон перестаёт звонить, но остаётся «на связи» со звонящим.
    /// </summary>
    public void StopRinging(Entity<RotaryPhoneComponent> callee)
    {
        callee.Comp.SoundEntity = _audio.Stop(callee.Comp.SoundEntity);

        if (callee.Comp.ConnectedPhoneStand is { } stand)
            UpdateAppearance(stand, RotaryPhoneVisuals.Base);
    }
}
