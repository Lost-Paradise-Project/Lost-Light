using Content.Server.Administration;
using Content.Server.Holiday;
using Content.Shared.Administration;
using Robust.Shared.Console;

namespace Content.Server._LP.Holiday;

[AdminCommand(AdminFlags.Fun)]
public sealed partial class HolidayEffectsSpawnCommand : LocalizedEntityCommands
{
    [Dependency] private HolidayEffectsSystem _effects = default!;
    [Dependency] private HolidaySpawnerMarkerSystem _markers = default!;

    public override string Command => "holidayeffects_spawn";

    public override void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length != 1)
        {
            shell.WriteError(Loc.GetString("shell-wrong-arguments-number"));
            return;
        }

        if (!_effects.HolidaysEnabled)
        {
            shell.WriteError(Loc.GetString("cmd-holidayeffects_spawn-disabled"));
            return;
        }

        if (!_effects.TryForce(args[0]))
        {
            shell.WriteError(Loc.GetString("cmd-holidayeffects_spawn-unknown", ("holiday", args[0])));
            return;
        }

        _markers.SpawnAll();
        shell.WriteLine(Loc.GetString("cmd-holidayeffects_spawn-done", ("holiday", args[0])));
    }

    public override CompletionResult GetCompletion(IConsoleShell shell, string[] args)
    {
        if (args.Length != 1)
            return CompletionResult.Empty;

        return CompletionResult.FromHintOptions(
            CompletionHelper.PrototypeIDs<HolidayPrototype>(),
            Loc.GetString("cmd-holidayeffects_spawn-hint"));
    }
}
