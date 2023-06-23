namespace Sadin.Cms.Domain.Aggregates.Announcements.ValueObjects;

public sealed class AnnouncementContent : ValueObject
{
    private AnnouncementContent(string value) => Value = value;

    public static AnnouncementContent Create(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainArgumentNullException($"{nameof(content)} can not be null or whitespace.");
        return new(content);
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected AnnouncementContent()
    {
    }
}