using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sadin.Cms.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApplication(this WebApplication app)
    {
        return app;
    }
}