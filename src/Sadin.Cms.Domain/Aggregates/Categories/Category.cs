using Sadin.Cms.Domain.Aggregates.Announcements;
using Sadin.Cms.Domain.Aggregates.Categories.ValueObjects;

namespace Sadin.Cms.Domain.Aggregates.Categories;

public sealed class Category : AggregateRoot, IAuditableEntity
{
    private Category(Guid id, CategoryTitle title, CategoryDescription description) : base(id)
    {
        Title = title ?? throw new DomainArgumentNullException($"{nameof(title)} can not be null.");
        Description = description ?? throw new DomainArgumentNullException($"{nameof(description)} can not be null.");
        Slug = CategorySlug.Create(title.Value.CreateSlug());
    }

    public CategoryTitle Title { get; private set; }
    public CategorySlug Slug { get; private set; }
    public CategoryDescription Description { get; private set; }
    
    public IReadOnlyCollection<Announcement> Announcements => _announcements;
    private List<Announcement> _announcements => new();


    public static Category Create(Guid id, CategoryTitle title, CategoryDescription description)
    {
        return new(id, title, description);
    }

    public void UpdateSlug(CategorySlug slug)
    {
        Slug = slug ?? throw new ArgumentNullException(nameof(slug));
    }

    protected Category()
    {
    }
}