using Sadin.Cms.Persistence.EntityConfigurations.Base;

namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class ContactMessageConfiguration : EntityMapBase<ContactMessage>
{
    public override void Configure(EntityTypeBuilder<ContactMessage> builder)
    {
        builder.ToTable("ContactMessages");
        builder.HasKey(x => x.Id);
        
        builder
            .OwnsOne(x => x.FullName)
            .Property(x => x.Value)
            .HasColumnName("FullName");
        builder
            .OwnsOne(x => x.Email)
            .Property(x => x.Value)
            .HasColumnName("Email");
        builder
            .OwnsOne(x => x.PhoneNumber)
            .Property(x => x.Value)
            .HasColumnName("PhoneNumber");
        builder
            .OwnsOne(x => x.Subject)
            .Property(x => x.Value)
            .HasColumnName("Subject");
        builder
            .OwnsOne(x => x.Content)
            .Property(x => x.Value)
            .HasColumnName("Content");
        
        base.Configure(builder);
    }
}