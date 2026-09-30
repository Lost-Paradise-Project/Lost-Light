using System.Text.RegularExpressions;
using Content.Server.Speech.Components;
using Content.Shared.Speech;

namespace Content.Server._Starlight.Speech.EntitySystems;

public sealed partial class FrontalLispSystem : EntitySystem
{
    [GeneratedRegex(@"[T]+[Ss]+|[S]+[Cc]+(?=[IiEeYy]+)|[C]+(?=[IiEeYy]+)|[P][Ss]+|([S]+[Tt]+|[T]+)(?=[Ii]+[Oo]+[Uu]*[Nn]*)|[C]+[Hh]+(?=[Ii]*[Ee]*)|[Z]+|[S]+|[X]+(?=[Ee]+)")]
    private static partial Regex RegexUpperTh();
    [GeneratedRegex(@"[t]+[s]+|[s]+[c]+(?=[iey]+)|[c]+(?=[iey]+)|[p][s]+|([s]+[t]+|[t]+)(?=[i]+[o]+[u]*[n]*)|[c]+[h]+(?=[i]*[e]*)|[z]+|[s]+|[x]+(?=[e]+)")]
    private static partial Regex RegexLowerTh();
    [GeneratedRegex(@"[E]+[Xx]+[Cc]*|[X]+")]
    private static partial Regex RegexUpperEcks();
    [GeneratedRegex(@"[e]+[x]+[c]*|[x]+")]
    private static partial Regex RegexLowerEcks();
    // LP edit start
    [GeneratedRegex("ц+")]
    private static partial Regex RegexLowerTsRu();
    [GeneratedRegex("Ц+")]
    private static partial Regex RegexUpperTsRu();
    [GeneratedRegex("с+")]
    private static partial Regex RegexLowerSRu();
    [GeneratedRegex("С+")]
    private static partial Regex RegexUpperSRu();
    [GeneratedRegex("з+")]
    private static partial Regex RegexLowerZRu();
    [GeneratedRegex("З+")]
    private static partial Regex RegexUpperZRu();
    // LP edit end
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<FrontalLispComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, FrontalLispComponent component, AccentGetEvent args)
    {
        var message = args.Message.Text;

        // handles ts, sc(i|e|y), c(i|e|y), ps, st(io(u|n)), ch(i|e), z, s
        message = RegexUpperTh().Replace(message, "TH");
        message = RegexLowerTh().Replace(message, "th");
        // handles ex(c), x
        message = RegexUpperEcks().Replace(message, "EKTH");
        message = RegexLowerEcks().Replace(message, "ekth");

        // LP edit start
        // фпафибо, тфарь, вдорово
        message = RegexLowerTsRu().Replace(message, "тф");
        message = RegexUpperTsRu().Replace(message, "ТФ");
        message = RegexLowerSRu().Replace(message, "ф");
        message = RegexUpperSRu().Replace(message, "Ф");
        message = RegexLowerZRu().Replace(message, "в");
        message = RegexUpperZRu().Replace(message, "В");
        // LP edit end

        args.Message.Text = message;
    }
}
