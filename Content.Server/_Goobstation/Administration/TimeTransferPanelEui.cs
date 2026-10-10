using Content.Server.Administration;
using Content.Server.Administration.Commands;
using Content.Server.Administration.Managers;
using Content.Server.Database;
using Content.Server.EUI;
using Content.Server.Players.PlayTimeTracking;
using Content.Shared._GoobStation.Administration;
using Content.Shared.Administration;
using Content.Shared.Eui;
using Robust.Server.Player;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
// LP edit start
using System.Linq;
using System.Threading.Tasks;
// LP edit end

namespace Content.Server._GoobStation.Administration;

public sealed partial class TimeTransferPanelEui : BaseEui
{
    [Dependency] private IAdminManager _adminMan = default!;
    [Dependency] private ILogManager _log = default!;
    [Dependency] private IPlayerLocator _playerLocator = default!;
    [Dependency] private IServerDbManager _databaseMan = default!;
    // LP edit start
    [Dependency] private IPlayerManager _playerManager = default!;
    [Dependency] private PlayTimeTrackingManager _playTimeTracking = default!;
    // LP edit end

    private readonly ISawmill _sawmill;

    public TimeTransferPanelEui()
    {
        IoCManager.InjectDependencies(this);

        _sawmill = _log.GetSawmill("admin.time_eui");
    }

    public override TimeTransferPanelEuiState GetNewState()
    {
        var hasFlag = _adminMan.HasAdminFlag(Player, AdminFlags.Playtime); // LP edit

        return new TimeTransferPanelEuiState(hasFlag);
    }

    public override void HandleMessage(EuiMessageBase msg)
    {
        base.HandleMessage(msg);

        if (msg is not TimeTransferEuiMessage message)
            return;

        TransferTime(message.PlayerId, message.TimeData, message.Overwrite);
    }

    public async void TransferTime(string playerId, List<TimeTransferData> timeData, bool overwrite)
    {
        if (!_adminMan.HasAdminFlag(Player, AdminFlags.Playtime)) // LP edit
        {
            _sawmill.Warning($"{Player.Name} ({Player.UserId} tried to add roles time without moderator flag)");
            return;
        }

        var playerData = await _playerLocator.LookupIdByNameAsync(playerId);
        if (playerData == null)
        {
            _sawmill.Warning($"{Player.Name} ({Player.UserId} tried to add roles time to not existing player {playerId})");
            SendMessage(new TimeTransferWarningEuiMessage(Loc.GetString("time-transfer-panel-no-player-database-message"), Color.Red));
            return;
        }

        // LP edit start
        await ApplyTime(playerData.Username, playerData.UserId, timeData, overwrite);
        // LP edit end
    }

    // LP edit start
    // Время пишется через PlayTimeTrackingManager: он сохраняет в БД и отправляет в NullLink,
    // а у игрока онлайн обновляет данные в памяти (иначе следующее сохранение затрёт БД).
    // Работает и для игроков не в сети.
    public async Task ApplyTime(string userName, NetUserId userId, List<TimeTransferData> timeData, bool overwrite)
    {
        // Только время этого сервера, без засчитанного с других серверов NullLink.
        var current = await _playTimeTracking.TryGetPlayTimesByUserName(userName);
        if (current == null)
        {
            SendMessage(new TimeTransferWarningEuiMessage(Loc.GetString("time-transfer-panel-no-player-database-message"), Color.Red));
            return;
        }

        var saved = 0;

        foreach (var data in timeData)
        {
            var time = TimeSpan.FromMinutes(PlayTimeCommandUtilities.CountMinutes(data.TimeString));

            if (overwrite)
                time -= current.GetValueOrDefault(data.PlaytimeTracker);

            if (time == TimeSpan.Zero)
                continue;

            if (await _playTimeTracking.TryAddTimeToTrackerByUserName(userName, data.PlaytimeTracker, time) != null)
                saved++;
        }

        if (_playerManager.TryGetSessionById(userId, out var session))
            _playTimeTracking.SaveSession(session);

        _sawmill.Info($"{Player.Name} ({Player.UserId} saved {saved} trackers for {userId})");

        var messageId = overwrite ? "time-transfer-panel-warning-set-success" : "time-transfer-panel-warning-add-success";
        SendMessage(new TimeTransferWarningEuiMessage(Loc.GetString(messageId), Color.LightGreen));
    }
    // LP edit end

    public override async void Opened()
    {
        base.Opened();
        _adminMan.OnPermsChanged += OnPermsChanged;
    }

    public override void Closed()
    {
        base.Closed();
        _adminMan.OnPermsChanged -= OnPermsChanged;
    }

    private void OnPermsChanged(AdminPermsChangedEventArgs args)
    {
        if (args.Player != Player)
        {
            return;
        }

        StateDirty();
    }
}
