namespace Sadin.Cms.Domain.Aggregates.Categories.ValueObjects;

public sealed class CategoryTitle : ValueObject
{
    private CategoryTitle(string value) => Value = value;

    public static CategoryTitle Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainArgumentNullException($"{nameof(title)} can not be null or whitespace.");
        return new(title);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected CategoryTitle()
    {
    }

}