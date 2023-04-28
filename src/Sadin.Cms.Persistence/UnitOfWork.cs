namespace Sadin.Cms.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CmsDbContext _dbContext;

    public UnitOfWork(CmsDbContext dbContext)
        =>_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}