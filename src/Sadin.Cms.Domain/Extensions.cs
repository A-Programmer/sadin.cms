using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sadin.Cms.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    public static WebApplication UseDomain(this WebApplication app)
    {
        return app;
    }
}