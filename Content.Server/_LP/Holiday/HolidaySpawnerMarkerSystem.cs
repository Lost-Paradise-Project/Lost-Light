using Content.Server._Starlight.Holiday;
using Content.Server.GameTicking;
using Content.Shared._LP.Holiday;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;

namespace Content.Server._LP.Holiday;

public sealed partial class HolidaySpawnerMarkerSystem : EntitySystem
{
    [Dependency] private HolidayEffectsSystem _effects = default!;
    [Dependency] private IPrototypeManager _prototype = default!;
    [Dependency] private IRobustRandom _random = default!;

    // Чтобы одна опечатка в маркере не засоряла лог при каждом проходе.
    private readonly HashSet<string> _reportedErrors = new();

    public override void Initialize()
    {
        // После HolidayVisualsSystem: к этому моменту праздники обновлены, приветствие и DoCelebrate уже вызваны.
        SubscribeLocalEvent<GameRunLevelChangedEvent>(OnRunLevelChanged, after: [typeof(HolidayVisualsSystem)]);
    }

    private void OnRunLevelChanged(GameRunLevelChangedEvent ev)
    {
        if (ev.New != GameRunLevel.InRound)
            return;

        SpawnAll();
    }

    public void SpawnAll()
    {
        var query = EntityQueryEnumerator<HolidaySpawnerMarkerComponent>();
        while (query.MoveNext(out var uid, out var marker))
        {
            TrySpawn((uid, marker));
        }
    }

    public bool TrySpawn(Entity<HolidaySpawnerMarkerComponent> ent)
    {
        if (!CanSpawn(ent, out var spawn))
            return false;

        // Шанс бросаем только когда всё остальное подходит: дубль не создаём и кубик зря не тратим.
        if (!_random.Prob(ent.Comp.Chance))
            return false;

        DoSpawn(ent, spawn);
        return true;
    }

    private bool CanSpawn(Entity<HolidaySpawnerMarkerComponent> ent, out EntProtoId spawn)
    {
        spawn = default;

        if (ent.Comp.Spawned is { } spawned && Exists(spawned) && !TerminatingOrDeleted(spawned))
            return false;

        if (!_effects.IsAnyActive(ent.Comp.Holiday, ent.Comp.ExtraHolidays))
            return false;

        if (ent.Comp.Spawn is not { } toSpawn)
            return false;

        if (!_prototype.HasIndex(toSpawn))
        {
            ReportOnce($"proto:{toSpawn}",
                $"Маркер праздника {ToPrettyString(ent)} ссылается на несуществующий прототип {toSpawn}.");
            return false;
        }

        spawn = toSpawn;
        return true;
    }

    private void DoSpawn(Entity<HolidaySpawnerMarkerComponent> ent, EntProtoId proto)
    {
        var xform = Transform(ent);
        var spawned = SpawnAttachedTo(proto, xform.Coordinates, rotation: xform.LocalRotation);

        var effect = EnsureComp<HolidayEffectComponent>(spawned);
        effect.Holiday = ent.Comp.Holiday;

        ent.Comp.Spawned = spawned;
    }

    private void ReportOnce(string key, string message)
    {
        if (_reportedErrors.Add(key))
            Log.Error(message);
    }
}
