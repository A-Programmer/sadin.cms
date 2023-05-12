using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sadin.Cms.Application.ContactUs.Events;
using Sadin.Cms.Application.Messaging.Models;
using Sadin.Cms.Infrastructure.Idempotence;

namespace Sadin.Cms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ContactMessageCreatedEventPublisher>();
        services.AddMediatR(cfg=>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);
        services.Configure<MessagingOptions>(
            configuration.GetSection("Messaging:RabbitMQ"));
        return services;
    }

    public static WebApplication UseApplication(this WebApplication app)
    {
        return app;
    }
}