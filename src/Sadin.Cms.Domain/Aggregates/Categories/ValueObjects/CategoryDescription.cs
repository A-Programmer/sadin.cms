namespace Sadin.Cms.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategoryDescription : ValueObject
{
    private CategoryDescription(string value) => Value = value;

    public static CategoryDescription Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainArgumentNullException($"{nameof(description)} can not be null of whitespace.");
        return new(description);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected CategoryDescription()
    {
    }
}