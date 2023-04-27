namespace Sadin.Cms.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UsePersistence(this WebApplication app)
    {
        return app;
    }
}