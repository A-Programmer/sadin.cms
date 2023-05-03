using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Sadin.Cms.Domain.Primitives;
using Sadin.Cms.Persistence.Outbox;

namespace Sadin.Cms.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CmsDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;

    public UnitOfWork(CmsDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
    }

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
            Entity entity = (Entity)entityEntry.Entity;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                {
                    entity.SetCreatorInfo(DateTimeOffset.Now, _currentUserService.GetCurrentUser().UserName);
                    break;
                }
                case EntityState.Modified:
                {
                    entity.SetModifierInfo(DateTimeOffset.Now, _currentUserService.GetCurrentUser().UserName);
                    break;
                }
                case EntityState.Deleted:
                {
                    entity.Delete();
                    entity.SetModifierInfo(DateTimeOffset.Now, _currentUserService.GetCurrentUser().UserName);
                    entityEntry.State = EntityState.Modified;
                    break;
                }
            }
        }
    }
}