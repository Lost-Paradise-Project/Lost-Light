using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

//
// License-Identifier: MIT
//

public sealed partial class CCVars
{
    /// <summary>
    ///     The range at which directional emotes can be used.
    /// </summary>
    public static readonly CVarDef<int> DirectionalEmoteRange =
        CVarDef.Create("chat.directional_emotes_range", 3, CVar.REPLICATED);

    /// <summary>
    ///     Maximum length of an emote message.
    /// </summary>
    public static readonly CVarDef<int> ChatMaxEmoteLength =
        CVarDef.Create("chat.max_emote_length", 10000, CVar.REPLICATED);
}
