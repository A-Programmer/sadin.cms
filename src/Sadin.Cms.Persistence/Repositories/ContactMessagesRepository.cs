namespace Sadin.Cms.Persistence.Repositories;

public sealed class ContactMessagesRepository : IContactMessagesRepository
{
    private readonly CmsDbContext _dbContext;

    public ContactMessagesRepository(CmsDbContext dbContext) => _dbContext = dbContext ?? throw new InfrastructureArgumentNullException(nameof(dbContext));

    public void Insert(ContactMessage message) =>
        _dbContext.Set<ContactMessage>().Add(message);

    public async Task<ContactMessage?> GetById(Guid id, CancellationToken cancellationToken)
    {
        ContactMessage message = await _dbContext.Set<ContactMessage>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (message is null)
            throw new InfrastructureEntityNotFoundException(id);
        
        return message;
    }
}