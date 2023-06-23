
using Sadin.Cms.Domain.Aggregates.Announcements;
using Sadin.Cms.Domain.Aggregates.Tags.ValueObjects;

namespace Sadin.Cms.Domain.Aggregates.Tags;

public sealed class Tag : AggregateRoot, IAuditableEntity
{
    private Tag(TagTitle title, TagName name)
    {
        Title = title;
        Slug = TagSlug.Create(name.Value.CreateSlug());
        Name = name;
    }

    public static Tag Create(TagTitle title, TagName name) => new(title, name);
    public TagTitle Title { get; private set; }
    public TagName Name { get; private set; }
    public TagSlug Slug { get; private set; }
    
    public IReadOnlyCollection<Announcement> Announcements => _announcements;
    private List<Announcement> _announcements = new();


    protected Tag()
    {
    }
}