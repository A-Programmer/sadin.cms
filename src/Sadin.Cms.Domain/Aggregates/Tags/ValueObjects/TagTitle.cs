namespace Sadin.Cms.Domain.Aggregates.Tags.ValueObjects;

public sealed class TagTitle : ValueObject
{
    private TagTitle(string value) => Value = value;

    public static TagTitle Create(string tagTitle)
    {
        if (string.IsNullOrWhiteSpace(tagTitle))
            throw new DomainArgumentNullException($"{nameof(tagTitle)} can not be null or whitespace.");
        return new(tagTitle);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}