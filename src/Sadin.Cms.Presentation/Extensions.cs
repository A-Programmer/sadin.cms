using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sadin.Cms.Presentation;

public static class Extensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);
        return serviceCollection;
    }

    public static WebApplication UsePresentation(this WebApplication app)
    {
        return app;
    }
}