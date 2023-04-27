namespace Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

public sealed class Content : ValueObject
{
    private Content(string value)
    {
        Value = value;
    }

    public static Content Create(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainArgumentNullException($"{nameof(content)} can not be null or whitespace.");
        return new Content(content);
    }
    
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}