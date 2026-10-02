using System.Text.RegularExpressions;
using Content.Shared._Starlight.Speech.Components;
using Content.Shared.Speech;
using Robust.Shared.Random;

namespace Content.Server._Starlight.Speech.EntitySystems;

public sealed partial class GrowlingAccentSystem : EntitySystem
{
    [Dependency] private IRobustRandom _random = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<GrowlingAccentComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, GrowlingAccentComponent component, AccentGetEvent args)
    {
        var message = args.Message.Text;

        // r => rrr
        message = Regexr().Replace(message, _random.Pick(new List<string> { "rr", "rrr" })
);
        // R => RRR
        message = RegexR().Replace(message, _random.Pick(new List<string> { "RR", "RRR" })
);
        // LP edit start
        // р => ррр
        message = RegexrRu().Replace(message, _random.Pick(new List<string> { "рр", "ррр" }));
        // Р => РРР
        message = RegexRRu().Replace(message, _random.Pick(new List<string> { "РР", "РРР" }));
        // LP edit end

        args.Message.Text = message;
    }

    [GeneratedRegex("r+")]
    private static partial Regex Regexr();
    [GeneratedRegex("R+")]
    private static partial Regex RegexR();
    // LP edit start
    [GeneratedRegex("р+")]
    private static partial Regex RegexrRu();
    [GeneratedRegex("Р+")]
    private static partial Regex RegexRRu();
    // LP edit end
}
