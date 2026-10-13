using System.Diagnostics.CodeAnalysis;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.RichText;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Client._Funkystation.Handwriting;

/// <summary>
/// this is a custom FontTag handler to support changing the font via FontPrototype
/// </summary>
public sealed class HandwritingFontTagHandler : IMarkupTagHandler
{
    public string Name => "hwfont";

    private static readonly Dictionary<(string, int), Font> FontCache = new();

    // LP edit start - в шрифтах почерка нет кириллицы, недостающие буквы берём из обычного шрифта
    private const string FallbackFontPath = "/Fonts/NotoSans/NotoSans-Regular.ttf";
    // Размер можно задать вручную тегом в бумаге, ограничиваем, чтобы нельзя было уронить клиент огромным шрифтом
    private const int MinSize = 8;
    private const int MaxSize = 32;
    // LP edit end

    public void PushDrawContext(MarkupNode node, MarkupDrawingContext context)
    {
        var pushed = false;

        var fontId = node.Value.StringValue;

        if (string.IsNullOrEmpty(fontId) && node.Attributes.TryGetValue("id", out var idParam))
        {
            fontId = idParam.StringValue;
        }

        if (!string.IsNullOrEmpty(fontId))
        {
            var protoMan = IoCManager.Resolve<IPrototypeManager>();
            var resCache = IoCManager.Resolve<IResourceCache>();

            if (protoMan.TryIndex<FontPrototype>(fontId, out var fontProto))
            {
                var size = 16; // baseline default

                if (node.Attributes.TryGetValue("size", out var sizeParam))
                {
                    if (sizeParam.LongValue.HasValue)
                        size = (int)sizeParam.LongValue.Value;
                    else if (!string.IsNullOrEmpty(sizeParam.StringValue) && int.TryParse(sizeParam.StringValue, out var parsedSize))
                        size = parsedSize;
                }
                else if (context.Font.Count > 0 && context.Font.Peek() is VectorFont vectorFont)
                {
                    size = vectorFont.Size;
                }

                size = Math.Clamp(size, MinSize, MaxSize); // LP edit
                var key = (fontProto.ID, size);
                if (!FontCache.TryGetValue(key, out var font))
                {
                    var fontRes = resCache.GetResource<FontResource>(fontProto.Path); // erm what the scallop
                    var fallbackRes = resCache.GetResource<FontResource>(FallbackFontPath); // LP edit
                    font = new StackedFont(new VectorFont(fontRes, size), new VectorFont(fallbackRes, size)); // LP edit
                    FontCache[key] = font;
                }

                context.Font.Push(font);
                pushed = true;
            }
        }

        // always push SOMETHING
        if (!pushed)
        {
            context.Font.Push(context.Font.Count > 0 ? context.Font.Peek() : null!);
        }
    }

    public void PopDrawContext(MarkupNode node, MarkupDrawingContext context)
    {
        if (context.Font.Count > 0)
        {
            context.Font.Pop();
        }
    }

    public string TextBefore(MarkupNode node)
    {
        return "";
    }

    public string TextAfter(MarkupNode node)
    {
        return "";
    }

    public bool TryCreateControl(MarkupNode node, [NotNullWhen(true)] out Control? control)
    {
        control = null;
        return false;
    }
}
