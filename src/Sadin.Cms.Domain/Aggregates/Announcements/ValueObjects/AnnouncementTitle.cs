namespace Sadin.Cms.Domain.Aggregates.Announcements.ValueObjects;

public sealed class AnnouncementTitle : ValueObject
{
    private AnnouncementTitle(string value) => Value = value;

    public static AnnouncementTitle Create(string title)
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

    protected AnnouncementTitle()
    {
    }
}