using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Sadin.Cms.Persistence.Repositories;

public sealed class ContactMessagesRepository : IContactMessagesRepository
{
    private readonly CmsDbContext _dbContext;

    public ContactMessagesRepository(CmsDbContext dbContext) => _dbContext = dbContext ?? throw new InfrastructureArgumentNullException(nameof(dbContext));

    public void Insert(ContactMessage message) =>
        _dbContext.Set<ContactMessage>().Add(message);

    public void Delete(ContactMessage message)
    {
        _dbContext.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
        _dbContext.ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
        _dbContext.Set<ContactMessage>().Remove(message);
    }

    public async Task<ContactMessage?> GetById(Guid id, CancellationToken cancellationToken)
    {
        ContactMessage message = await _dbContext.Set<ContactMessage>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (message is null)
            throw new InfrastructureEntityNotFoundException(id);
        
        return message;
    }
}