namespace Sadin.Cms.Persistence;

public sealed class CmsDbContext : DbContext, IUnitOfWork
{
    public CmsDbContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
}