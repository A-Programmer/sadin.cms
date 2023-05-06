using Sadin.Cms.Api.Middlewares;

namespace Sadin.Cms.Api;

public static class Extensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
        serviceCollection
            .AddScoped<ExceptionHandlingMiddleware>()
            .AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
        return serviceCollection;
    }

    public static WebApplication UseApi(this WebApplication app)
    {
        app.UseCustomExceptionHandling();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }
}