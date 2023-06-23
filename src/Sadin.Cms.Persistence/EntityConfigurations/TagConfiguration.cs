using Sadin.Cms.Domain.Aggregates.Tags;
using Sadin.Cms.Persistence.EntityConfigurations.Base;

namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class TagConfiguration : EntityMapBase<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder
            .OwnsOne(x => x.Title)
            .Property(x => x.Value)
            .HasColumnName("Title");
        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.Value)
            .HasColumnName("Name");
        builder
            .OwnsOne(x => x.Slug)
            .Property(x => x.Value)
            .HasColumnName("Slug");
        
        base.Configure(builder);
    }
}