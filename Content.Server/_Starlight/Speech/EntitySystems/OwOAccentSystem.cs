using Content.Server.Speech.Components;
using Content.Shared._Starlight.Speech;
using Content.Shared.Speech;
using Content.Shared.StatusEffectNew;
// LP edit start
using System.Linq;
using System.Text.RegularExpressions;
// LP edit end

namespace Content.Server._Starlight.Speech.EntitySystems;

public sealed class OwOAccentSystem : EntitySystem
{
    private static readonly IReadOnlyDictionary<string, string> _specialWords = new Dictionary<string, string>()
    {
        { "you", "wu" },
        { "are", "r" },
        { "hello", "mew" },
        { "love", "luv" },
        { "please", "plez" },
        { "food", "noms" },
        { "cute", "koot" },
        { "now", "meow" },
        { "look", "lookee" },
        { "little", "lil" },
    };

    // LP edit start
    // Русские слова заменяем только целиком, чтобы не задевать части других слов
    private static readonly IReadOnlyDictionary<string, string> _specialWordsRu = new Dictionary<string, string>()
    {
        { "привет", "мур" },
        { "ты", "ти" },
        { "еда", "ням-ням" },
        { "сейчас", "мяу" },
        { "пожалуйста", "пазязя" },
        { "милый", "мивый" },
        { "маленький", "мавенький" },
    };

    private static readonly Regex RussianWordRegex = new(@"\b[а-яё]+\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static string ReplaceRussianWords(string text)
        => RussianWordRegex.Replace(text, m =>
        {
            if (!_specialWordsRu.TryGetValue(m.Value.ToLowerInvariant(), out var repl))
                return m.Value;

            if (m.Value.All(char.IsUpper))
                return repl.ToUpperInvariant();

            return char.IsUpper(m.Value[0]) ? char.ToUpperInvariant(repl[0]) + repl[1..] : repl;
        });
    // LP edit end

    public override void Initialize()
    {
        SubscribeLocalEvent<OwOAccentComponent, AccentGetEvent>(OnAccent);
        SubscribeLocalEvent<OwOAccentComponent, StatusEffectRelayedEvent<AccentGetEvent>>(OnAccentRelayed);
    }

    public SpeechMessage Accentuate(SpeechMessage message)
    {
        foreach (var (word, repl) in _specialWords)
        {
            message.Text = message.Text.Replace(word, repl);
            message.Tts = (message.Tts ?? message.Text).Replace(word, repl);
        }
        // LP edit start
        message.Text = ReplaceRussianWords(message.Text);
        message.Tts = ReplaceRussianWords(message.Tts ?? message.Text);
        // LP edit end
        message.Text = message.Text
            .Replace("r", "w").Replace("R", "W")
            .Replace("l", "w").Replace("L", "W") // LP edit
            // LP edit start
            .Replace("р", "в").Replace("Р", "В")
            .Replace("л", "в").Replace("Л", "В");
            // LP edit end

        return message;
    }

    private void OnAccent(Entity<OwOAccentComponent> entity, ref AccentGetEvent args)
        => args.Message = Accentuate(args.Message);

    private void OnAccentRelayed(Entity<OwOAccentComponent> entity, ref StatusEffectRelayedEvent<AccentGetEvent> args)
        => args.Args.Message = Accentuate(args.Args.Message);
}
