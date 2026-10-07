using System.Linq;
using Content.Shared.GameTicking;
using Content.Server.Station.Components;
using Robust.Shared.Network;
using Robust.Shared.Player;
using System.Text;

namespace Content.Server.GameTicking; // LP edit, {} > ;

    public sealed partial class GameTicker
    {
        [ViewVariables]
        private readonly Dictionary<NetUserId, PlayerGameStatus> _playerGameStatuses = new();

        [ViewVariables]
        private TimeSpan _roundStartTime;

        /// <summary>
        /// How long before RoundStartTime do we load maps.
        /// </summary>
        [ViewVariables]
        public TimeSpan RoundPreloadTime { get; } = TimeSpan.FromSeconds(15);

        [ViewVariables]
        private TimeSpan _pauseTime;

        [ViewVariables]
        public new bool Paused { get; set; }

        [ViewVariables]
        private bool _roundStartCountdownHasNotStartedYetDueToNoPlayers;

        /// <summary>
        /// The game status of a players user Id. May contain disconnected players
        /// </summary>
        public IReadOnlyDictionary<NetUserId, PlayerGameStatus> PlayerGameStatuses => _playerGameStatuses;

        public void UpdateInfoText() => RaiseNetworkEvent(GetInfoMsg(), Filter.Empty().AddPlayers(_playerManager.NetworkedSessions)); // LP edit, expression body for method

        private string GetInfoText()
        {
            var preset = CurrentPreset ?? Preset;
            if (preset == null)
            {
                return string.Empty;
            }

            var playerCount = $"{_playerManager.PlayerCount}";
            var readyCount = _playerGameStatuses.Values.Count(x => x == PlayerGameStatus.ReadyToPlay);

            var stationNames = new StringBuilder();
            var query =
                EntityQueryEnumerator<StationJobsComponent, StationSpawningComponent, MetaDataComponent>();

            var foundOne = false;

            while (query.MoveNext(out _, out _, out var meta))
            {
                foundOne = true;
                if (stationNames.Length > 0)
                    stationNames.Append('\n');

                stationNames.Append(meta.EntityName);
            }

            if (!foundOne)
            {
                stationNames.Append(_gameMapManager.GetSelectedMap()?.MapName ??
                                    Loc.GetString("game-ticker-no-map-selected"));
            }

            var gmTitle = (Decoy == null) ? Loc.GetString(preset.ModeTitle) : Loc.GetString(Decoy.ModeTitle);
            var desc = (Decoy == null) ? Loc.GetString(preset.Description) : Loc.GetString(Decoy.Description);
            return Loc.GetString(
                RunLevel == GameRunLevel.PreRoundLobby
                    ? "game-ticker-get-info-preround-text"
                    : "game-ticker-get-info-text",
                ("roundId", RoundId),
                ("playerCount", playerCount),
                ("readyCount", readyCount),
                ("mapName", stationNames.ToString()),
                ("gmTitle", string.IsNullOrWhiteSpace(GamemodeNameOverride) ? gmTitle : Loc.GetString(GamemodeNameOverride)), //Starlight edit: gamemode name override
                ("desc", string.IsNullOrWhiteSpace(GamemodeDescOverride) ? desc : Loc.GetString(GamemodeDescOverride))); //Starlight edit: gamemode desc override
        }

        private TickerConnectionStatusEvent GetConnectionStatusMsg() => new(RoundStartTimeSpan); // LP edit, expression body for method + simplification of expression new()

        private TickerLobbyStatusEvent GetStatusMsg(ICommonSession session)
        {
            _playerGameStatuses.TryGetValue(session.UserId, out var status);
            return new TickerLobbyStatusEvent(RunLevel != GameRunLevel.PreRoundLobby, LobbyBackground, status == PlayerGameStatus.ReadyToPlay, _roundStartTime, RoundPreloadTime, RoundStartTimeSpan, Paused);
        }

        private void SendStatusToAll()
        {
            foreach (var player in _playerManager.Sessions)
            {
                RaiseNetworkEvent(GetStatusMsg(player), player.Channel);
            }
        }

        private TickerLobbyInfoEvent GetInfoMsg() => new(GetInfoText()); // LP edit, expression body for method

        private void UpdateLateJoinStatus() => RaiseNetworkEvent(new TickerLateJoinStatusEvent(DisallowLateJoin)); // LP edit, expression body for method

        public bool PauseStart(bool pause = true)
        {
            if (Paused == pause)
            {
                return false;
            }

            Paused = pause;

            if (pause)
            {
                _pauseTime = _gameTiming.CurTime;
            }
            else if (_pauseTime != default)
            {
                _roundStartTime += _gameTiming.CurTime - _pauseTime;
            }

            RaiseNetworkEvent(new TickerLobbyCountdownEvent(_roundStartTime, Paused));

            _chatManager.DispatchServerAnnouncement(Loc.GetString(Paused
                ? "game-ticker-pause-start"
                : "game-ticker-pause-start-resumed"));

            return true;
        }

        public bool TogglePause()
        {
            PauseStart(!Paused);
            return Paused;
        }

        public void ToggleReadyAll(bool ready)
        {
            var status = ready ? PlayerGameStatus.ReadyToPlay : PlayerGameStatus.NotReadyToPlay;
            foreach (var playerUserId in _playerGameStatuses.Keys)
            {
                if (!_playerManager.TryGetSessionById(playerUserId, out var playerSession)  || _playerGameStatuses[playerUserId] == status) // Moffstation - Ready manifest
                    continue;

                _playerGameStatuses[playerUserId] = status; // Moffstation - Ready Manifest

                RaiseNetworkEvent(GetStatusMsg(playerSession), playerSession.Channel);

                // Moffstation - Start - Ready manifest
                var ev = new PlayerToggleReadyEvent(playerSession);
                RaiseLocalEvent(ref ev);
                // Moffstation - End
            }

            UpdateInfoText(); // LP edit
        }

        public void ToggleReady(ICommonSession player, bool ready)
        {
            if (!_playerGameStatuses.ContainsKey(player.UserId))
                return;

            if (!_userDb.IsLoadComplete(player))
                return;

            if (RunLevel != GameRunLevel.PreRoundLobby)
            {
                return;
            }

            // Starlight start - add ready possibility check
            // Ensure that the player has a character enabled with a compatible job that can even join.
            var readyPossible = (_prefsManager.GetPreferencesOrNull(player.UserId)?.JobPrioritiesFiltered().Count ?? 0) != 0;

            var status = ready && readyPossible // LP edit
                ? PlayerGameStatus.ReadyToPlay
                : PlayerGameStatus.NotReadyToPlay;
            // Starlight end - add ready possibility check

            // Moffstation - Ready manifest
            if (_playerGameStatuses[player.UserId] == status)
            {
                return;
            }
            // Moffstatation - End
            _playerGameStatuses[player.UserId] = status;
            RaiseNetworkEvent(GetStatusMsg(player), player.Channel);

            // Moffstation - Start - Ready Manifest
            var ev = new PlayerToggleReadyEvent(player);
            RaiseLocalEvent(ref ev);
            // Moffstation - End

            // update server info to reflect new ready count
            UpdateInfoText();
        }

        public bool UserHasJoinedGame(ICommonSession session)
            => UserHasJoinedGame(session.UserId);

        public bool UserHasJoinedGame(NetUserId userId)
            => PlayerGameStatuses.TryGetValue(userId, out var status) && status == PlayerGameStatus.JoinedGame;
    }

    // Moffstation - Start - Ready Manifest
    [ByRefEvent]
    public record struct PlayerToggleReadyEvent(ICommonSession PlayerSession);
    // Moffstation - End
