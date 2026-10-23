using Content.Shared._ES.Viewcone.Components;
using Content.Shared.Mobs.Components;

namespace Content.Shared._LP.Viewcone;

/// <summary>
/// Сужает конус зрения в софткрите и крите. Раньше это делал SoftcritSystem Funky Station.
/// </summary>
public sealed class ViewconeMobStateModifierSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ViewconeMobStateModifierComponent, ESViewconeGetAngleModifierEvent>(OnGetAngleModifier);
    }

    private void OnGetAngleModifier(Entity<ViewconeMobStateModifierComponent> ent, ref ESViewconeGetAngleModifierEvent args)
    {
        if (!TryComp<MobStateComponent>(ent, out var mobState))
            return;

        if (ent.Comp.Modifiers.TryGetValue(mobState.CurrentState, out var modifier))
            args.ModifyAngle(modifier);
    }
}
