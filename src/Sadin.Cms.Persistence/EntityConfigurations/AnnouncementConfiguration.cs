using Sadin.Cms.Domain.Aggregates.Announcements;
using Sadin.Cms.Persistence.EntityConfigurations.Base;

namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class AnnouncementConfiguration : EntityMapBase<Announcement>
{
    public override void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements");

        builder
            .OwnsOne(x => x.Title)
            .Property(x => x.Value)
            .HasColumnName("Title");
        builder
            .OwnsOne(x => x.Slug)
            .Property(x => x.Value)
            .HasColumnName("Slug");
        builder
            .OwnsOne(x => x.Description)
            .Property(x => x.Value)
            .HasColumnName("Description");
        builder
            .OwnsOne(x => x.Content)
            .Property(x => x.Value)
            .HasColumnName("Content");
            
        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Announcements);
        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Announcements);
        base.Configure(builder);
    }
}