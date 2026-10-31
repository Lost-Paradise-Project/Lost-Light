using Content.Server._Trauma.Phones;
using Content.Server.Power.EntitySystems;
using Content.Server.Telephone;
using Content.Shared._LP.Phones;
using Content.Shared._Trauma.Phones.Components;
using Content.Shared.Examine;
using Content.Shared.Popups;
using Content.Shared.Power;
using Content.Shared.Telephone;
using Robust.Shared.Map;

namespace Content.Server._LP.Phones;

/// <summary>
/// Телефоны с <c>RequiresExchange</c> звонят через ближайшую АТС на своей карте. Нет АТС, нет питания
/// или она саботирована - линия не отвечает, а уже идущие звонки обрываются.
/// </summary>
public sealed partial class TelephoneExchangeSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    [Dependency] private SharedPopupSystem _popup = default!;
    [Dependency] private TelephoneSystem _telephone = default!;
    [Dependency] private RotaryPhoneSystem _rotary = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TelephoneExchangeComponent, PowerChangedEvent>(OnPowerChanged);
        SubscribeLocalEvent<TelephoneExchangeComponent, ExaminedEvent>(OnExamined);
        SubscribeLocalEvent<TelephoneComponent, TelephoneCallAttemptEvent>(OnCallAttempt);
    }

    #region Line status

    /// <summary>
    /// Состояние линии телефона. Телефону, которому АТС не нужна, линия доступна всегда.
    /// </summary>
    public TelephoneLineStatus GetLineStatus(EntityUid phone, bool requiresExchange)
    {
        if (!requiresExchange)
            return TelephoneLineStatus.Working;

        var xform = Transform(phone);
        if (xform.MapID == MapId.Nullspace)
            return TelephoneLineStatus.NoExchange;

        var phonePos = _transform.GetWorldPosition(xform);
        Entity<TelephoneExchangeComponent>? nearest = null;
        var nearestDistance = float.MaxValue;

        var query = EntityQueryEnumerator<TelephoneExchangeComponent, TransformComponent>();
        while (query.MoveNext(out var uid, out var exchange, out var exchangeXform))
        {
            if (exchangeXform.MapID != xform.MapID)
                continue;

            var distance = (_transform.GetWorldPosition(exchangeXform) - phonePos).LengthSquared();
            if (distance >= nearestDistance)
                continue;

            nearest = (uid, exchange);
            nearestDistance = distance;
        }

        return nearest is { } found ? GetExchangeStatus(found) : TelephoneLineStatus.NoExchange;
    }

    public TelephoneLineStatus GetExchangeStatus(Entity<TelephoneExchangeComponent> exchange)
    {
        if (exchange.Comp.Sabotaged)
            return TelephoneLineStatus.Sabotaged;

        return this.IsPowered(exchange, EntityManager) ? TelephoneLineStatus.Working : TelephoneLineStatus.NoPower;
    }

    /// <summary>
    /// Можно ли соединить два телефона: линия нужна и звонящему, и вызываемому.
    /// </summary>
    public bool CanConnect(EntityUid source, bool sourceRequiresExchange, EntityUid receiver, bool receiverRequiresExchange)
    {
        return GetLineStatus(source, sourceRequiresExchange) == TelephoneLineStatus.Working
            && GetLineStatus(receiver, receiverRequiresExchange) == TelephoneLineStatus.Working;
    }

    #endregion

    #region Sabotage

    public void SetSabotaged(Entity<TelephoneExchangeComponent> exchange, bool sabotaged)
    {
        if (exchange.Comp.Sabotaged == sabotaged)
            return;

        exchange.Comp.Sabotaged = sabotaged;
        DropCallsWithoutLine();
    }

    private void OnPowerChanged(Entity<TelephoneExchangeComponent> exchange, ref PowerChangedEvent args)
    {
        if (!args.Powered)
            DropCallsWithoutLine();
    }

    /// <summary>
    /// Линия пропала: обрываем звонки телефонов, которым она больше не доступна.
    /// </summary>
    private void DropCallsWithoutLine()
    {
        var telephones = EntityQueryEnumerator<TelephoneComponent>();
        while (telephones.MoveNext(out var uid, out var telephone))
        {
            if (telephone.RequiresExchange
                && _telephone.IsTelephoneEngaged((uid, telephone))
                && GetLineStatus(uid, true) != TelephoneLineStatus.Working)
            {
                _telephone.EndTelephoneCalls((uid, telephone));
            }
        }

        var rotary = EntityQueryEnumerator<RotaryPhoneComponent>();
        while (rotary.MoveNext(out var uid, out var phone))
        {
            if (phone.RequiresExchange
                && phone.ConnectedPhone != null
                && GetLineStatus(uid, true) != TelephoneLineStatus.Working)
            {
                _rotary.DropCall((uid, phone), "phone-popup-line-lost");
            }
        }
    }

    #endregion

    private void OnCallAttempt(Entity<TelephoneComponent> source, ref TelephoneCallAttemptEvent args)
    {
        if (CanConnect(source, source.Comp.RequiresExchange, args.Receiver, args.Receiver.Comp.RequiresExchange))
            return;

        args.Cancelled = true;

        if (args.User is { } user)
            _popup.PopupEntity(Loc.GetString("telephone-exchange-line-down"), source, user);
    }

    private void OnExamined(Entity<TelephoneExchangeComponent> exchange, ref ExaminedEvent args)
    {
        var status = GetExchangeStatus(exchange);
        args.PushMarkup(Loc.GetString(status switch
        {
            TelephoneLineStatus.NoPower => "telephone-exchange-examine-no-power",
            TelephoneLineStatus.Sabotaged => "telephone-exchange-examine-sabotaged",
            _ => "telephone-exchange-examine-working",
        }));
    }
}
