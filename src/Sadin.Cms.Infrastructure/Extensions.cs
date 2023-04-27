using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sadin.Cms.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        return app;
    }
}