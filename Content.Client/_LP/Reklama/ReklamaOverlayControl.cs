using Content.Shared._LP.Reklama;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Prototypes;

namespace Content.Client._LP.Reklama;

public static class ReklamaControlManager
{
    public static List<Control> GetAdIcons()
    {
        var protos = IoCManager.Resolve<IPrototypeManager>().EnumeratePrototypes<ReklamaPrototype>();
        var uriOpener = IoCManager.Resolve<IUriOpener>();
        List<Control> reklama = [];

        foreach (var proto in protos)
        {
            var tooltip = string.IsNullOrEmpty(proto.Description)
                ? proto.Name
                : $"{proto.Name}\n{proto.Description}";

            var btn = new Button
            {
                ToolTip = tooltip,
                ModulateSelfOverride = Color.Transparent,
            };

            btn.AddChild(new TextureRect
            {
                TexturePath = proto.Icon.ToString(),
                VerticalAlignment = Control.VAlignment.Center,
                HorizontalAlignment = Control.HAlignment.Center,
                TextureScale = proto.Scale,
            });

            if (!string.IsNullOrEmpty(proto.Url))
                btn.OnPressed += _ => uriOpener.OpenUri(proto.Url);

            reklama.Add(btn);
        }

        return reklama;
    }
}
