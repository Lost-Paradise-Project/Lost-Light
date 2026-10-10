using Content.Shared.Access.Components;
using Content.Shared.Containers.ItemSlots;
using Content.Shared._Corvax.Documents;
using Content.Shared.Lathe;
using Content.Shared.Paper;
using Content.Shared.Station;

namespace Content.Server._Corvax.Documents;

public sealed partial class DocumentPrinterSystem : EntitySystem
{
    [Dependency] private ItemSlotsSystem _itemSlots = default!;
    [Dependency] private PaperSystem _paper = default!;
    [Dependency] private SharedStationSystem _station = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<DocumentPrinterComponent, LatheGetResultEvent>(SetContentDocument);
    }

    private void SetContentDocument(Entity<DocumentPrinterComponent> ent, ref LatheGetResultEvent result)
    {
        // LP edit start - текст уже загружен из файла (TextFilePaperContent на MapInit), это не ключ локализации
        if (!TryComp<PaperComponent>(result.ResultItem, out var paper))
            return;

        IdCardComponent? idCard = null;
        if (_itemSlots.TryGetSlot(ent.Owner, ent.Comp.SlotName, out var slot) && slot.Item is { } idCardEntity)
            TryComp(idCardEntity, out idCard);

        var station = _station.GetOwningStation(ent.Owner);
        var stationName = station != null ? Name(station.Value) : null;

        _paper.SetContent((result.ResultItem, paper), FormatString(paper.Content, stationName, idCard));
        // LP edit end
    }

    public string FormatString(string content, string? station, IdCardComponent? idCard = null)
    {
        // LP edit - дату ставит игрок тегом [datetime]
        return content
            .Replace(Loc.GetString("doc-var-station"), station ?? Loc.GetString("doc-text-printer-default-station"))
            .Replace(Loc.GetString("doc-var-name"), idCard?.FullName ?? Loc.GetString("doc-text-printer-default-name"))
            .Replace(Loc.GetString("doc-var-job"), idCard?.LocalizedJobTitle ?? Loc.GetString("doc-text-printer-default-job"));
    }
}
