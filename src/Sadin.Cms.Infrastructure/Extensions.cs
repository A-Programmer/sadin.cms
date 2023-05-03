using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Sadin.Cms.Infrastructure.Authentication;
using Sadin.Cms.Infrastructure.BackgroundJobs;
using Sadin.Cms.Infrastructure.EmailServices;

namespace Sadin.Cms.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEmailSender, EmailSender>();
        serviceCollection.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));
            configure
                .AddJob<ProcessOutboxMessagesJob>(jobKey)
                .AddTrigger(
                    trigger =>
                        trigger.ForJob(jobKey)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(10)
                                    .RepeatForever()));
            configure.UseMicrosoftDependencyInjectionJobFactory();
        });
        serviceCollection.AddQuartzHostedService();
        serviceCollection.AddScoped<IUserSession, UserSession>();
        serviceCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        serviceCollection.AddHttpContextAccessor();
        
        return serviceCollection;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        return app;
    }
}