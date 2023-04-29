namespace Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

public sealed class FullName : ValueObject
{
    public const int MaxLength = 150;
    private FullName(string value)
    {
        Value = value;
    }

    protected FullName()
    {
        
    }

    public static FullName Create(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new DomainArgumentNullException($"{nameof(fullName)} can not be null or whitespace.");
        if (fullName.Length > MaxLength)
            throw new ArgumentException($"{nameof(fullName)} can not be more than 150 characters.");
        return new FullName(fullName);
    }
    
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}