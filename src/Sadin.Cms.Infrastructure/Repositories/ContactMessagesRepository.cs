namespace Sadin.Cms.Infrastructure.Repositories;

public sealed class ContactMessagesRepository : IContactMessagesRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ContactMessagesRepository(ApplicationDbContext dbContext) => _dbContext = dbContext ?? throw new InfrastructureArgumentNullException(nameof(dbContext));

    public void Insert(ContactMessage message) =>
        _dbContext.Set<ContactMessage>().Add(message);
}