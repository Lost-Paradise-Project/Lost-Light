using System.IO;
using Content.Client.Viewport;
using Content.Shared._WL.ScreenCapture;
using Robust.Client.Graphics;
using Robust.Client.State;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Content.Client._WL.ScreenCapture;

public sealed partial class CaptureSystem : EntitySystem
{
    [Dependency] private IClyde _clyde = default!;
    [Dependency] private IStateManager _state = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<CaptureScreenRequestEvent>(OnCaptureRequest);
    }

    private async void OnCaptureRequest(CaptureScreenRequestEvent ev)
    {
        try
        {
            switch (ev.Type)
            {
                case PhotoCaptureType.Clyde:
                    using (var capture = await _clyde.ScreenshotAsync(ScreenshotType.Final))
                    {
                        SendImage(ev.RequestId, capture);
                    }
                    break;

                case PhotoCaptureType.Viewport:
                    CaptureViewport(ev.RequestId);
                    break;
            }
        }
        catch
        {
            SendFailure(ev.RequestId);
        }
    }

    // Только игровая сцена, без интерфейса. Нужен, если Clyde отдаёт чёрный кадр (например, OpenGL ES 2 на Linux).
    private void CaptureViewport(int requestId)
    {
        if (_state.CurrentState is not IMainViewportState state)
        {
            SendFailure(requestId);
            return;
        }

        state.Viewport.Viewport.Screenshot(screenshot =>
        {
            try
            {
                SendImage(requestId, screenshot);
            }
            catch
            {
                SendFailure(requestId);
            }
            finally
            {
                screenshot.Dispose();
            }
        });
    }

    private void SendImage<T>(int requestId, Image<T> image) where T : unmanaged, IPixel<T>
    {
        using var ms = new MemoryStream();
        image.SaveAsJpeg(ms);

        RaiseNetworkEvent(new CaptureScreenResponseEvent(requestId, ms.ToArray()));
    }

    private void SendFailure(int requestId)
    {
        RaiseNetworkEvent(new CaptureScreenResponseEvent(requestId, null));
    }
}
