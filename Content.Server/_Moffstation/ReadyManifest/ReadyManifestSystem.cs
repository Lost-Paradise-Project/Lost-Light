// SPDX-FileCopyrightText: 2026 Space Station 14 Contributors
//
// SPDX-License-Identifier: MIT

using System.Linq;
using Content.Server.EUI;
using Content.Server.GameTicking;
using Content.Server.GameTicking.Events;
using Content.Server.Preferences.Managers;
using Content.Server.Station.Systems;
using Content.Shared._Moffstation.ReadyManifest;
using Content.Shared.GameTicking;
using Content.Shared.Preferences;
using Content.Shared.Roles;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;

namespace Content.Server._Moffstation.ReadyManifest;

public sealed partial class ReadyManifestSystem : EntitySystem /// LP edit , added "sealed"
{
    /// LP edit start
    // private readonly > private
    [Dependency] private EuiManager _euiManager = default!;
    [Dependency] private GameTicker _gameTicker = default!;
    [Dependency] private IServerPreferencesManager _prefsManager = default!;
    [Dependency] private IPrototypeManager _protoMan = default!;
    /// LP edit end

    private readonly Dictionary<ICommonSession, ReadyManifestEui> _openEuis = [];

    // A dictionary for each job type, then another for each priority level for that job type
    private readonly Dictionary<ProtoId<JobPrototype>, ReadyManifestJobCount> _jobCounts = []; /// LP edit , int > ReadyManifestJobCount

    public override void Initialize()
    {
        SubscribeNetworkEvent<RequestReadyManifestMessage>(OnRequestReadyManifest);
        SubscribeLocalEvent<PlayerToggleReadyEvent>(OnPlayerToggleReady);
        SubscribeLocalEvent<JobPrioritiesUpdatedEvent>(OnJobPrioritiesUpdated); // LP edit
        SubscribeLocalEvent<RoundStartingEvent>(OnRoundStarting);
    }

    private void OnRoundStarting(RoundStartingEvent ev)
    {
        foreach (var eui in _openEuis.Values.ToList()) // LP edit
        {
            eui.Close();
        }

        _openEuis.Clear();
    }

    private void OnRequestReadyManifest(RequestReadyManifestMessage message, EntitySessionEventArgs args)
    {
        // LP edit start
        if (_gameTicker.RunLevel != GameRunLevel.PreRoundLobby)
            return;
        // LP edit end

        BuildReadyManifest();
        OpenEui(args.SenderSession);
    }

    private void OnPlayerToggleReady(ref PlayerToggleReadyEvent ev)
    {
        BuildReadyManifest();
        UpdateEuis();
    }

    private void BuildReadyManifest()
    {
        _jobCounts.Clear();

        var jobs = _protoMan.EnumeratePrototypes<JobPrototype>();
        foreach (var job in jobs)
        {
            if (!job.SetPreference)
                continue;
            _jobCounts.Add(job.ID, new ReadyManifestJobCount(0, 0)); /// LP edit
        }
        foreach (var userId in _gameTicker.PlayerGameStatuses.Keys)
        {
            UpdateByPlayer(userId);
        }
    }

    private void UpdateByPlayer(NetUserId userId)
    {
        // If they aren't ready, then don't bother counting them
        if (_gameTicker.PlayerGameStatuses[userId] != PlayerGameStatus.ReadyToPlay)
            return;

        if (!_prefsManager.TryGetCachedPreferences(userId, out var preferences))
            return;

        var jobs = preferences.JobPrioritiesFiltered(); // LP edit

        foreach (var (job, priority) in jobs) // LP edit
        {
            if (!_jobCounts.ContainsKey(job))
                continue;

            if (priority < JobPriority.Medium)
                continue;

            /// LP edit start
            // _jobCounts[job]++;
            var count = _jobCounts[job];

            if (priority == JobPriority.High)
            {
                count = count with { High = count.High + 1 };
            }
            else if (priority == JobPriority.Medium)
            {
                count = count with { Medium = count.Medium + 1 };
            }

            _jobCounts[job] = count;
            /// LP edit end
        }
    }

    public IDictionary<ProtoId<JobPrototype>, ReadyManifestJobCount> GetReadyManifest() => _jobCounts.AsReadOnly(); /// LP edit , int > ReadyManifestJobCount

    private void OpenEui(ICommonSession session)
    {
        if (_openEuis.ContainsKey(session))
        {
            return;
        }

        var eui = new ReadyManifestEui(this);
        _openEuis.Add(session, eui);
        _euiManager.OpenEui(eui, session);
        eui.StateDirty();
    }

    private void UpdateEuis()
    {
        foreach (var eui in _openEuis.Values)
        {
            eui.StateDirty();
        }
    }

    /// LP edit start
    public void CloseEui(ICommonSession session) => _openEuis.Remove(session);
    //{
    //    if (_openEuis.Remove(session, out var eui))
    //        eui.Close();
    //}

    private void OnJobPrioritiesUpdated(ref JobPrioritiesUpdatedEvent ev)
    {
        BuildReadyManifest();
        UpdateEuis();
    }
    /// LP edit end
}
