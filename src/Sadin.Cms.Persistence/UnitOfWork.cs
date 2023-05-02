using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Sadin.Cms.Domain.Primitives;
using Sadin.Cms.Persistence.Outbox;

namespace Sadin.Cms.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CmsDbContext _dbContext;

    public UnitOfWork(CmsDbContext dbContext)
        => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ConvertDomainEventsToOutboxMessages();
        UpdateAuditableEntities();
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void ConvertDomainEventsToOutboxMessages()
    {
        var outboxMessages = _dbContext.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.GetDomainEvents();
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                OccuredDate = DateTimeOffset.Now,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(
                    domainEvent,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    })
            })
            .ToList();

        _dbContext.Set<OutboxMessage>()
            .AddRange(outboxMessages);
    }

    private void UpdateAuditableEntities()
    {
        _dbContext.ChangeTracker.DetectChanges();
        IEnumerable<EntityEntry<IAuditableEntity>> entries =
            _dbContext
                .ChangeTracker
                .Entries<IAuditableEntity>();

        foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
        {
            entityEntry.DetectChanges();
            switch (entityEntry.State)
            {
                case EntityState.Added:
                {
                    entityEntry.Property(a => a.CreatedOnUtc)
                        .CurrentValue = DateTimeOffset.Now;
                    break;
                }
                case EntityState.Modified:
                {
                    entityEntry.Property(a => a.ModifiedOnUtc)
                        .CurrentValue = DateTimeOffset.Now;
                    break;
                }
                case EntityState.Deleted:
                {
                    Entity entity = (Entity)entityEntry.Entity;
                    entity.Delete();
                    entityEntry.Property(x => x.ModifiedOnUtc)
                        .CurrentValue = DateTimeOffset.Now;
                    entityEntry.State = EntityState.Modified;
                    break;
                }
            }
        }
    }
}