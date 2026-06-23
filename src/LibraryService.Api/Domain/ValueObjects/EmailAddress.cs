namespace LibraryService.Api.Domain.ValueObjects;

/// <summary>
/// Immutable EmailAddress value object. It protects invariants at the domain boundary.
/// </summary>
public sealed class EmailAddress : ValueObject
{
    private EmailAddress(string value) => Value = value;

    public string Value { get; }

    public static EmailAddress Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("EmailAddress is required.", nameof(value));
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) throw new ArgumentException("Email address is invalid.", nameof(value));
        return new EmailAddress(value);
    }

    public static bool TryCreate(string value, out EmailAddress? result)
    {
        try
        {
            result = Create(value);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator string(EmailAddress value) => value.Value;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}