namespace Sadin.Cms.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategorySlug : ValueObject
{
    private CategorySlug(string value) => Value = value;

    public static CategorySlug Create(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainArgumentNullException($"{nameof(slug)} can not be null of whitespace.");
        return new(slug);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected CategorySlug()
    {
    }
}