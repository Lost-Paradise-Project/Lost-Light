using System.Text.RegularExpressions;
using Content.Server.Speech.Components;
using Content.Shared.Speech;

namespace Content.Server._Starlight.Speech.EntitySystems;

public sealed partial class LizardAccentSystem : EntitySystem
{
    [GeneratedRegex("s+")]
    private static partial Regex RegexLowerS();

    [GeneratedRegex("S+")]
    private static partial Regex RegexUpperS();

    [GeneratedRegex(@"(\w)x")]
    private static partial Regex RegexInternalX();

    [GeneratedRegex(@"\bx([\-|r|R]|\b)")]
    private static partial Regex RegexLowerEndX();

    [GeneratedRegex(@"\bX([\-|r|R]|\b)")]
    private static partial Regex RegexUpperEndX();

    // LP edit start
    [GeneratedRegex("[сз]+")]
    private static partial Regex RegexLowerSRu();

    [GeneratedRegex("[СЗ]+")]
    private static partial Regex RegexUpperSRu();

    [GeneratedRegex("ш+")]
    private static partial Regex RegexLowerShRu();

    [GeneratedRegex("Ш+")]
    private static partial Regex RegexUpperShRu();

    [GeneratedRegex("ч+")]
    private static partial Regex RegexLowerChRu();

    [GeneratedRegex("Ч+")]
    private static partial Regex RegexUpperChRu();
    // LP edit end

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<LizardAccentComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, LizardAccentComponent component, AccentGetEvent args)
    {
        // hissss
        args.Message.Text = RegexLowerS().Replace(args.Message.Text, "sss");
        // hiSSS
        args.Message.Text = RegexUpperS().Replace(args.Message.Text, "SSS");
        // ekssit
        args.Message.Text = RegexInternalX().Replace(args.Message.Text, "$1kss");
        // ecks
        args.Message.Text = RegexLowerEndX().Replace(args.Message.Text, "ecks$1");
        // eckS
        args.Message.Text = RegexUpperEndX().Replace(args.Message.Text, "ECKS$1");

        // LP edit start
        // зссдрассствуй
        args.Message.Text = RegexLowerSRu().Replace(args.Message.Text, "ссс");
        args.Message.Text = RegexUpperSRu().Replace(args.Message.Text, "ССС");
        // шшшшто
        args.Message.Text = RegexLowerShRu().Replace(args.Message.Text, "шшш");
        args.Message.Text = RegexUpperShRu().Replace(args.Message.Text, "ШШШ");
        // щщщего
        args.Message.Text = RegexLowerChRu().Replace(args.Message.Text, "щщщ");
        args.Message.Text = RegexUpperChRu().Replace(args.Message.Text, "ЩЩЩ");
        // LP edit end
    }
}
