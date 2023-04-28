using Sadin.Cms.Persistence.Outbox;

namespace Sadin.Cms.Persistence.EntityConfigurations;

public sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages");
    }
}