namespace Sadin.Cms.Domain.Aggregates.Announcements.ValueObjects;

public sealed class AnnouncementSlug : ValueObject
{
    private AnnouncementSlug(string value) => Value = value;

    public static AnnouncementSlug Create(string slug)
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

    protected AnnouncementSlug()
    {
    }
}