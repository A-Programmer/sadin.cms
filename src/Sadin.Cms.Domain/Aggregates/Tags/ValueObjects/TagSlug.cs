namespace Sadin.Cms.Domain.Aggregates.Tags.ValueObjects;

public sealed class TagSlug : ValueObject
{
    private TagSlug(string value) => Value = value;

    public static TagSlug Create(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainArgumentNullException($"{nameof(slug)} can not be null or whitespace.");
        return new(slug);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}