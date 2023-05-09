using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sadin.Cms.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UseShared(this WebApplication app)
    {
        return app;
    }
}