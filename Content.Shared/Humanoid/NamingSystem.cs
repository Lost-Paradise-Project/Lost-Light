using System.Linq;
using Content.Shared.Dataset; // LP edit
using Content.Shared.Humanoid.Prototypes;
using Content.Shared.Random.Helpers;
using Robust.Shared.Random;
using Robust.Shared.Prototypes;
using Robust.Shared.Enums;

namespace Content.Shared.Humanoid
{
    /// <summary>
    /// Figure out how to name a humanoid with these extensions.
    /// </summary>
    public sealed partial class NamingSystem : EntitySystem
    {
        private static readonly ProtoId<SpeciesPrototype> FallbackSpecies = "Human";

        [Dependency] private IRobustRandom _random = default!;
        [Dependency] private IPrototypeManager _prototypeManager = default!;
        private static readonly List<string> _bannedIDs = new() { "69", "67", "8008", "420" }; // Starlight edit: IDs that experiments can't random generate as names

        public string GetName(string species, Gender? gender = null)
        {
            // if they have an old species or whatever just fall back to human I guess?
            // Some downstream is probably gonna have this eventually but then they can deal with fallbacks.
            if (!_prototypeManager.TryIndex(species, out SpeciesPrototype? speciesProto))
            {
                speciesProto = _prototypeManager.Index(FallbackSpecies);
                Log.Warning($"Unable to find species {species} for name, falling back to {FallbackSpecies}");
            }

            switch (speciesProto.Naming)
            {
                case SpeciesNaming.First:
                    return Loc.GetString("namepreset-first",
                        ("first", GetFirstName(speciesProto, gender)));
                case SpeciesNaming.TheFirstofLast:
                    return Loc.GetString("namepreset-thefirstoflast",
                        // LP edit start
                        ("first", GetFirstName(speciesProto, gender)), ("last", GetLastName(speciesProto, gender)));
                        // LP edit end
                case SpeciesNaming.FirstDashFirst:
                    return Loc.GetString("namepreset-firstdashfirst",
                        ("first1", GetFirstName(speciesProto, gender)), ("first2", GetFirstName(speciesProto, gender)));
                case SpeciesNaming.LastFirst: // 🌟Starlight begin - Rodentia
                    return Loc.GetString("namepreset-lastfirst",
                        // LP edit start
                        ("last", GetLastName(speciesProto, gender)), ("first", GetFirstName(speciesProto, gender))); // 🌟Starlight end
                        // LP edit end
                case SpeciesNaming.FirstLast:
                default:
                    return Loc.GetString("namepreset-firstlast",
                        // LP edit start
                        ("first", GetFirstName(speciesProto, gender)), ("last", GetLastName(speciesProto, gender)));
                        // LP edit end
                // Starlight begin
                case SpeciesNaming.PrefixSuffix:
                    return Loc.GetString("namepreset-prefixsuffix",
                        // LP edit start
                        ("prefix", GetFirstName(speciesProto, gender)), ("suffix", GetLastName(speciesProto, gender)));
                        // LP edit end
                case SpeciesNaming.IdFirst:
                    return Loc.GetString("namepreset-idfirst",
                        ("id", GetRandomId(4)), ("first", GetFirstName(speciesProto, gender)));
                // Starlight end
            }
        }

        public string GetFirstName(SpeciesPrototype speciesProto, Gender? gender = null)
        {
            switch (gender)
            {
                case Gender.Male:
                    return _random.Pick(_prototypeManager.Index(speciesProto.MaleFirstNames));
                case Gender.Female:
                    return _random.Pick(_prototypeManager.Index(speciesProto.FemaleFirstNames));
                default:
                    if (_random.Prob(0.5f))
                        return _random.Pick(_prototypeManager.Index(speciesProto.MaleFirstNames));
                    else
                        return _random.Pick(_prototypeManager.Index(speciesProto.FemaleFirstNames));
            }
        }

        // Starlight begin
        public string GetRandomId(int length)
        {
            // start at 100 to avoid low numbers
            var id = _random.Next(100, (int)Math.Pow(10, length)-1).ToString().PadLeft(length, '0');

            // if random contains a bannedID, try again... this could technically loop forever, too lazy to calculate the chance for that tho >.>
            return _bannedIDs.Any(substring => id.Contains(substring)) ? GetRandomId(length) : id;
        }
        // Starlight end

        // LP edit start
        // Расы с общими фамилиями (люди, дворфы и т. д.) получают мужские/женские фамилии без правки их прототипов.
        private static readonly ProtoId<LocalizedDatasetPrototype> CommonLastNames = "NamesLast";
        private static readonly ProtoId<LocalizedDatasetPrototype> CommonMaleLastNames = "NamesLastMale";
        private static readonly ProtoId<LocalizedDatasetPrototype> CommonFemaleLastNames = "NamesLastFemale";

        public string GetLastName(SpeciesPrototype speciesProto, Gender? gender = null)
        {
            var common = speciesProto.LastNames == CommonLastNames;
            var dataset = gender switch
            {
                Gender.Male => speciesProto.MaleLastNames ?? (common ? CommonMaleLastNames : speciesProto.LastNames),
                Gender.Female => speciesProto.FemaleLastNames ?? (common ? CommonFemaleLastNames : speciesProto.LastNames),
                _ => speciesProto.LastNames,
            };

            return _random.Pick(_prototypeManager.Index(dataset));
        }
        // LP edit end
    }
}
