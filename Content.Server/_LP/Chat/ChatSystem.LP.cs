using Content.Server._NullLink.PlayerData;
using Robust.Shared.Player;

namespace Content.Server.Chat.Systems;

public sealed partial class ChatSystem
{
    [Dependency] private INullLinkPlayerManager _lpPlayerRoles = default!;

    /// <summary>
    /// Добавляет перед именем титул игрока из NullLink (как в OOC).
    /// </summary>
    private string LPWithTitle(ICommonSession player, string name)
    {
        if (_lpPlayerRoles.TryGetPlayerData(player.UserId, out var playerData)
            && !string.IsNullOrEmpty(playerData.Title))
            return $"{playerData.Title} {name}";

        return name;
    }
}
