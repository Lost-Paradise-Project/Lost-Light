namespace Content.Server._LP.Phones;

/// <summary>
/// Можно ли позвонить с телефона, и если нельзя - почему.
/// </summary>
public enum TelephoneLineStatus : byte
{
    Working,
    NoExchange,
    NoPower,
    Sabotaged,
}
