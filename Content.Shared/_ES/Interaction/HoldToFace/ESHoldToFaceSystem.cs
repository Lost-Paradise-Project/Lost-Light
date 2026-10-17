using Content.Shared._Funkystation.CCVar; // LP edit
using Content.Shared.CombatMode;
using Content.Shared.Input;
using Robust.Shared.Configuration; // LP edit
using Robust.Shared.Input.Binding;
using Robust.Shared.Player;

namespace Content.Shared._ES.Interaction.HoldToFace;

public sealed partial class ESHoldToFaceSystem : EntitySystem
{
    [Dependency] private SharedCombatModeSystem _combat = default!;
    [Dependency] private IConfigurationManager _cfg = default!; // LP edit

    public override void Initialize()
    {
        base.Initialize();

        CommandBinds.Builder
            .Bind(ContentKeyFunctions.ESHoldToFace,
                InputCmdHandler.FromDelegate(args => ToggleRotator(args, true), args => ToggleRotator(args, false), false, false))
            .Register<ESHoldToFaceSystem>();
    }

    private void ToggleRotator(ICommonSession? session, bool value)
    {
        if (session?.AttachedEntity is not { } ent || !HasComp<ESHoldToFaceComponent>(ent) || HasComp<ESForcedFacingComponent>(ent))
            return;

        // Don't try and override combat mode doing the same thing
        if (TryComp<CombatModeComponent>(ent, out var combat) && combat is { ToggleMouseRotator: true, IsInCombatMode: true })
            return;

        // LP edit start
        // постоянный поворот к курсору сам держит MouseRotator
        if (_cfg.GetCVar(ViewconeCCVars.AlwaysFaceCursor))
            return;
        // LP edit end

        _combat.SetMouseRotatorComponents(ent, value);
    }
}
