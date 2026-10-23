// LuaWorld - This file is licensed under AGPLv3
// Copyright (c) 2025 LuaWorld
// See AGPLv3.txt for details.
// Special Permission:
// In addition to AGPLv3, the author grants the "Мёртвый Космос" project
// the right to use this code under a separate custom license agreement.

// Ported from Lua-Frontier (sector-frontier-14, PR #172, cf42ec431ee239a38e727505d112b49b248486a3), adapted for Lost-Light.

using Content.Shared.Explosion;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._LP.HardsuitDna;

/// <summary>
/// Привязка скафандра к ДНК владельца. Чужой носитель получает отсчёт, после которого скафандр взрывается.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(SharedHardsuitDnaSystem))]
public sealed partial class HardsuitDnaComponent : Component
{
    /// <summary>
    /// Выключатель привязки. Нужен скафандрам, которые наследуют компонент от родителя, но привязку пока не получают.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool Enabled = true;

    /// <summary>
    /// ДНК владельца. <c>null</c> - скафандр не привязан и привяжется к первому надевшему.
    /// </summary>
    [DataField, AutoNetworkedField]
    public string? Dna;

    /// <summary>
    /// Привязка заблокирована: владелец не может её сбросить.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool Locked;

    /// <summary>
    /// Сколько у чужого носителя есть времени, чтобы снять скафандр.
    /// </summary>
    [DataField]
    public TimeSpan CountdownDuration = TimeSpan.FromSeconds(5);

    /// <summary>
    /// Множитель мощности взрыва (базовая мощность задана в системе, как в оригинале).
    /// </summary>
    [DataField]
    public float ExplosionIntensity = 1f;

    [DataField]
    public ProtoId<ExplosionPrototype> ExplosionType = "Default";

    /// <summary>
    /// Гибать ли носителя при взрыве.
    /// </summary>
    [DataField]
    public bool GibWearer = true;

    /// <summary>
    /// Привязывать ли скафандр к персонажу, у которого он оказался в руках или на теле при спавне, не дожидаясь надевания.
    /// </summary>
    [DataField]
    public bool AutoBindOnSpawn = true;

    [DataField]
    public SoundSpecifier BeepSound = new SoundPathSpecifier("/Audio/Effects/beep1.ogg");
}
