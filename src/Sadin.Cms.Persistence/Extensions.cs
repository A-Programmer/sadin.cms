using Microsoft.Extensions.Configuration;

namespace Sadin.Cms.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CmsDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                x => x.MigrationsAssembly("Sadin.Cms.Persistence"));
        });
        
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IContactMessagesRepository, ContactMessagesRepository>();
        return serviceCollection;
    }

    public static WebApplication UsePersistence(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<CmsDbContext>();
        context.Database.Migrate();
        return app;
    }
}