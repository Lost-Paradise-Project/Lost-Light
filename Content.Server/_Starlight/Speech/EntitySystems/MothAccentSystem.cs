using System.Text.RegularExpressions;
using Content.Server.Speech.Components;
using Content.Shared.Speech;

namespace Content.Server._Starlight.Speech.EntitySystems;

public sealed partial class MothAccentSystem : EntitySystem
{
    [GeneratedRegex("z{1,3}", RegexOptions.IgnoreCase)]
    private static partial Regex RegexBuzz();

    // LP edit start
    [GeneratedRegex("ж{1,3}|з{1,3}", RegexOptions.IgnoreCase)]
    private static partial Regex RegexBuzzRu();
    // LP edit end

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<MothAccentComponent, AccentGetEvent>(OnAccent);
    }

    // LP edit start
    private void OnAccent(EntityUid uid, MothAccentComponent component, AccentGetEvent args)
    {
        // buzzz - extend z sounds
        args.Message.Text = RegexBuzz().Replace(args.Message.Text, m =>
            char.IsUpper(m.Value[0]) ? "ZZZ" : "zzz");

        // жжжук, ззздесь — тянем ж и з
        args.Message.Text = RegexBuzzRu().Replace(args.Message.Text, m =>
            new string(m.Value[0], 3));
    }
    // LP edit end
}
