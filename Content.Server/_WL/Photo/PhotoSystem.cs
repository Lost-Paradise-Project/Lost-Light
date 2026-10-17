using Content.Server.Hands.Systems;
using Content.Server.Materials;
using Content.Server.Popups;
using Content.Shared._WL.Photo;
using Content.Shared._WL.Photo.Filters;
using Content.Shared.Interaction.Events;
using Content.Server.Administration.Logs;
using Content.Shared.Database;
using Content.Shared.Hands;
using Content.Shared.Materials;
using Content.Shared.Timing;
using Content.Shared.UserInterface;
using Robust.Server.Audio;
using Robust.Server.GameObjects;
using Robust.Shared.Containers;

namespace Content.Server._WL.Photo;

public sealed partial class PhotoSystem : SharedPhotoSystem
{
    [Dependency] private UserInterfaceSystem _userInterface = default!;
    [Dependency] private HandsSystem _hands = default!;
    [Dependency] private PopupSystem _popup = default!;
    [Dependency] private MaterialStorageSystem _material = default!;
    [Dependency] private TransformSystem _transform = default!;
    [Dependency] private UseDelaySystem _delay = default!;
    [Dependency] private AudioSystem _audio = default!;
    [Dependency] private IAdminLogManager _adminLog = default!; // LP edit

    //96 KB
    const int MAX_SIZE = 1024 * 96;

    private const int MaxPhotoSide = 1024; // LP edit

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PhotoCameraComponent, ActivatableUIOpenAttemptEvent>(OnOpenCameraInterfaceAttempt);
        Subs.BuiEvents<PhotoCameraComponent>(PhotoCameraUiKey.Key, subs =>
        {
            subs.Event<BoundUIClosedEvent>(OnCameraBoundUiClose);
            subs.Event<PhotoCameraTakeImageMessage>(OnTakeImageMessage);
        });
        SubscribeLocalEvent<PhotoCameraComponent, MaterialAmountChangedEvent>(OnPaperInserted);
        SubscribeLocalEvent<PhotoCameraComponent, DroppedEvent>(OnCameraDropped);
        // LP edit start
        SubscribeLocalEvent<PhotoCameraComponent, GotUnequippedHandEvent>(OnCameraUnequipped);
        SubscribeLocalEvent<PhotoCameraComponent, ComponentShutdown>(OnCameraShutdown);
        // LP edit end

        SubscribeLocalEvent<PhotoCardComponent, AfterActivatableUIOpenEvent>(OnOpenCardInterface);
        SubscribeLocalEvent<PhotoCameraComponent, EntInsertedIntoContainerMessage>(OnFilterInserted);
        SubscribeLocalEvent<PhotoCameraComponent, EntRemovedFromContainerMessage>(OnFilterRemoved);
    }

    private void OnOpenCameraInterfaceAttempt(EntityUid uid, PhotoCameraComponent component, ActivatableUIOpenAttemptEvent args)
    {
        if (component.User != null)
        {
            args.Cancel();
            return;
        }

        if (!_hands.IsHolding(args.User, uid))
        {
            _popup.PopupEntity(Loc.GetString("photo-camera-not-holding"), uid, args.User);

            args.Cancel();
            return;
        }
    }

    private void OnCameraBoundUiClose(EntityUid uid, PhotoCameraComponent component, BoundUIClosedEvent args)
    {
        if (component.User == null)
            return;

        RemComp<PhotoCameraUserComponent>(component.User.Value);
        component.User = null;
    }

    private void OnTakeImageMessage(EntityUid uid, PhotoCameraComponent component, PhotoCameraTakeImageMessage message)
    {
        // LP edit start
        if (component.User == null || message.Actor != component.User)
            return;
        // LP edit end

        if (message.Data.Length > MAX_SIZE)
            return;

        if (!IsValidPhoto(message.Data)) // LP edit
            return;

        TryTakeImage(uid, component, message.Data);
    }

    private void OnPaperInserted(EntityUid uid, PhotoCameraComponent component, ref MaterialAmountChangedEvent args) // LP edit
    {
        UpdateCameraInterface(uid, component, component.User);
    }

    private void OnCameraDropped(EntityUid uid, PhotoCameraComponent component, DroppedEvent args)
    {
        if (component.User == null || args.User != component.User)
            return;

        _userInterface.CloseUis(uid);
    }

    private void TryTakeImage(EntityUid uid, PhotoCameraComponent component, byte[] imageData)
    {
        if (_delay.IsDelayed(uid))
            return;

        _delay.TryResetDelay(uid);

        if (PrintCard(uid, component, imageData))
            _audio.PlayPvs(component.PhotoSound, uid);
        else
            _audio.PlayPvs(component.ErrorSound, uid);
    }

    private bool PrintCard(EntityUid uid, PhotoCameraComponent component, byte[] imageData)
    {
        if (!_material.TryChangeMaterialAmount(uid, component.CardMaterial, -component.CardCost))
        {
            if (component.User != null)
                _popup.PopupEntity(Loc.GetString("photo-camera-no-paper"), uid, component.User.Value);

            return false;
        }

        var card = Spawn(component.CardPrototype);
        _transform.SetMapCoordinates(card, _transform.GetMapCoordinates(uid));

        if (TryComp<PhotoCardComponent>(card, out var photo))
            photo.ImageData = imageData;

        // LP edit start
        if (component.User != null)
            _adminLog.Add(LogType.Action, LogImpact.Low,
                $"{ToPrettyString(component.User.Value):user} took a photo {ToPrettyString(card):photo} with {ToPrettyString(uid):camera}");
        // LP edit end

        if (component.User != null)
            _hands.TryPickupAnyHand(component.User.Value, card);

        UpdateCameraInterface(uid, component, component.User);

        return true;
    }

    public bool CheckPngSignature(ReadOnlySpan<byte> data)
    {
        if (data.Length < 8) return false;
        return data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47 &&
                data[4] == 0x0D && data[5] == 0x0A && data[6] == 0x1A && data[7] == 0x0A;
    }

    private void OnFilterInserted(EntityUid uid, PhotoCameraComponent component, EntInsertedIntoContainerMessage args)
    {
        if (!TryComp<PhotoCameraFilterComponent>(args.Entity, out var filter))
            return;

        if (args.Container.ID != component.FilterSlot)
            return;

        EntityManager.AddComponents(uid, filter.FilterComponents);
    }

    private void OnFilterRemoved(EntityUid uid, PhotoCameraComponent component, EntRemovedFromContainerMessage args)
    {
        if (!TryComp<PhotoCameraFilterComponent>(args.Entity, out var filter))
            return;

        if (args.Container.ID != component.FilterSlot)
            return;

        EntityManager.RemoveComponents(uid, filter.FilterComponents);
    }

    #region LP
    /// <summary>
    /// PNG с ограничением размеров из IHDR: маленький файл может распаковаться в огромную картинку у всех, кто откроет фото.
    /// </summary>
    public bool IsValidPhoto(ReadOnlySpan<byte> data)
    {
        if (data.Length < 24 || !CheckPngSignature(data))
            return false;

        if (data[12] != 'I' || data[13] != 'H' || data[14] != 'D' || data[15] != 'R')
            return false;

        var width = (data[16] << 24) | (data[17] << 16) | (data[18] << 8) | data[19];
        var height = (data[20] << 24) | (data[21] << 16) | (data[22] << 8) | data[23];

        return width is > 0 and <= MaxPhotoSide && height is > 0 and <= MaxPhotoSide;
    }

    private void OnCameraUnequipped(EntityUid uid, PhotoCameraComponent component, GotUnequippedHandEvent args)
    {
        if (component.User == null || args.User != component.User)
            return;

        _userInterface.CloseUis(uid);
    }

    private void OnCameraShutdown(EntityUid uid, PhotoCameraComponent component, ComponentShutdown args)
    {
        if (component.User is { } user && !TerminatingOrDeleted(user))
            RemComp<PhotoCameraUserComponent>(user);

        component.User = null;
    }
    #endregion

    // Photo Card

    private void OnOpenCardInterface(EntityUid uid, PhotoCardComponent component, AfterActivatableUIOpenEvent args)
    {
        var state = new PhotoCardUiState(component.ImageData);
        _userInterface.SetUiState(uid, PhotoCardUiKey.Key, state);
    }
}
