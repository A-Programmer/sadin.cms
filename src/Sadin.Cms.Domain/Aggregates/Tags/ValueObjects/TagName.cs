namespace Sadin.Cms.Domain.Aggregates.Tags.ValueObjects;

public sealed class TagName : ValueObject
{
    private TagName(string value) => Value = value;

    public static TagName Create(string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
            throw new DomainArgumentNullException($"{nameof(tagName)} can not be null or whitespace.");
        return new(tagName);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}