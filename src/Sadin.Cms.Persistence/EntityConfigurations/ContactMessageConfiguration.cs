namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
{
    public void Configure(EntityTypeBuilder<ContactMessage> builder)
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
    }
}