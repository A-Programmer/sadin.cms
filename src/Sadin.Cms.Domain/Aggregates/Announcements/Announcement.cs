using Sadin.Cms.Domain.Aggregates.Announcements.ValueObjects;
using Sadin.Cms.Domain.Aggregates.Categories;
using Sadin.Cms.Domain.Aggregates.Tags;

namespace Sadin.Cms.Domain.Aggregates.Announcements;

public sealed class Announcement : AggregateRoot, IAuditableEntity
{
    private Announcement(Guid id, AnnouncementTitle title, AnnouncementDescription description,
        AnnouncementContent content, bool isPublished)
    {
        Title = title;
        Slug = AnnouncementSlug.Create(title.Value.CreateSlug());
        Description = description;
        Content = content;
        IsPublished = isPublished;
    }
    
    public AnnouncementTitle Title { get; private set; }
    public AnnouncementSlug Slug { get; private set; }
    public AnnouncementDescription Description { get; private set; }
    public AnnouncementContent Content { get; private set; }
    public bool IsPublished { get; private set; }
    
    public IReadOnlyCollection<Tag> Tags => _tags;
    private List<Tag> _tags = new();
    
    public IReadOnlyCollection<Category> Categories => _categories;
    private List<Category> _categories = new();
    

    public static Announcement Create(Guid id, AnnouncementTitle title, AnnouncementDescription description,
        AnnouncementContent content, bool isPublished)
    {
        return new(id, title, description, content, isPublished);
    }

    public void Publish() => IsPublished = true;
    public void Draft() => IsPublished = false;
    public void ChangeStatus() => IsPublished = !IsPublished;
    
    #region Tags
    public void AddTags(Tag[] tags) => _tags.AddRange(tags);

    public void RemoveTags(Tag[] tags)
    {
        foreach (Tag tag in tags)
            _tags.Remove(tag);
    }

    public void ClearTags() => _tags.Clear();
    # endregion
    
    #region Categories
    public void AddCategories(Category[] categories) => _categories.AddRange(categories);

    public void RemoveCategories(Category[] categories)
    {
        foreach (Category category in categories)
            _categories.Remove(category);
    }

    public void ClearCategories() => _categories.Clear();
    # endregion
    
    protected Announcement()
    {
    }
}