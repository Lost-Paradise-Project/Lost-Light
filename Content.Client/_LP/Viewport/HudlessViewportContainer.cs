using Content.Client._Starlight.Antags.Vampires;
using Content.Client.CombatMode;
using Content.Client.Mining;
using Content.Client.Overlays;
using Content.Client.StatusIcon;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Shared.Timing;

namespace Content.Client._LP.Viewport;

/// <summary>
/// Скрывает худы во вложенном вьюпорте камеры, основной экран не затрагивается.
/// </summary>
public sealed partial class HudlessViewportContainer : Control
{
    [Dependency] private IOverlayManager _overlay = default!;

    private static readonly Type[] HudOverlays =
    [
        typeof(StatusIconOverlay),
        typeof(EntityHealthBarOverlay),
        typeof(BlackAndWhiteOverlay),
        typeof(NoirOverlay),
        typeof(HysteriaVisionOverlay),
        typeof(MiningOverlay),
        typeof(ColoredScreenBorderOverlay),
    ];

    private readonly List<Overlay> _hidden = new();

    public bool HideHud { get; set; } = true;

    public HudlessViewportContainer()
    {
        IoCManager.InjectDependencies(this);
    }

    protected override void PreRenderChildren(ref ControlRenderArguments args)
    {
        base.PreRenderChildren(ref args);

        if (!HideHud)
            return;

        foreach (var type in HudOverlays)
        {
            if (!_overlay.TryGetOverlay(type, out var overlay))
                continue;

            _overlay.RemoveOverlay(overlay);
            _hidden.Add(overlay);
        }
    }

    protected override void PostRenderChildren(ref ControlRenderArguments args)
    {
        RestoreOverlays();

        base.PostRenderChildren(ref args);
    }

    protected override void FrameUpdate(FrameEventArgs args)
    {
        base.FrameUpdate(args);

        // На случай, если отрисовка детей прервалась исключением
        RestoreOverlays();
    }

    private void RestoreOverlays()
    {
        if (_hidden.Count == 0)
            return;

        foreach (var overlay in _hidden)
        {
            _overlay.AddOverlay(overlay);
        }

        _hidden.Clear();
    }
}
