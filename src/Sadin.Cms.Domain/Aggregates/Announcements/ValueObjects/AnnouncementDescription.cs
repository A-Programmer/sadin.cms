namespace Sadin.Cms.Domain.Aggregates.Announcements.ValueObjects;

public sealed class AnnouncementDescription : ValueObject
{
    private AnnouncementDescription(string value) => Value = value;

    public static AnnouncementDescription Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainArgumentNullException($"{nameof(description)} can not be null or whitespace.");
        return new(description);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected AnnouncementDescription()
    {
    }
}