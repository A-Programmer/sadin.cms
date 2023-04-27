namespace Sadin.Cms.Infrastructure.EntityConfigurations;

public sealed class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
{
    public void Configure(EntityTypeBuilder<ContactMessage> builder)
    {
        builder.ToTable("ContactMessages");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(50);
        builder.Property(x => x.Subject)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Content)
            .IsRequired();
    }
}