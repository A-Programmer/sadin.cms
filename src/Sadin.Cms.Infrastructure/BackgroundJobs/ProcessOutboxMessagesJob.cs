using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using Sadin.Cms.Persistence;
using Sadin.Cms.Persistence.Outbox;
using Sadin.Common.Abstractions;

namespace Sadin.Cms.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob : IJob
{
    private readonly CmsDbContext _dbContext;
    private readonly IPublisher _publisher;

    public ProcessOutboxMessagesJob(CmsDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessage> messages = await _dbContext
            .Set<OutboxMessage>()
            .Where(x => x.ProcessedDate == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        foreach (OutboxMessage outboxMessage in messages)
        {
            IDomainEvent? domainEvent = JsonConvert
                .DeserializeObject<IDomainEvent>(outboxMessage.Content,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
            
            if (domainEvent is null)
                continue;
            
            await _publisher.Publish(domainEvent, context.CancellationToken);
            outboxMessage.ProcessedDate = DateTimeOffset.Now;
        }

        await _dbContext.SaveChangesAsync();
    }
}