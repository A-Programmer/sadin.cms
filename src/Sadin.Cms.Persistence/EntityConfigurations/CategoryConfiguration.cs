using Sadin.Cms.Domain.Aggregates.Categories;
using Sadin.Cms.Persistence.EntityConfigurations.Base;

namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class CategoryConfiguration : EntityMapBase<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

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
        
        base.Configure(builder);
    }
}