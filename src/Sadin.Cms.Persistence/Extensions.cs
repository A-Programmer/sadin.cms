using Microsoft.Extensions.Configuration;
using Sadin.Cms.Persistence.Interceptors;

namespace Sadin.Cms.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<ConvertDomainEventsToOutboxMessagesInterceptor>();
        
        serviceCollection.AddDbContext<CmsDbContext>((sp, options) =>
        {
            var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                x => x.MigrationsAssembly("Sadin.Cms.Persistence"))
                .AddInterceptors(interceptor);
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