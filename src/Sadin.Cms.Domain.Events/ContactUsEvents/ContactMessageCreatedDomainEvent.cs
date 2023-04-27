namespace Sadin.Cms.Domain.Events.ContactUsEvents;

public sealed record ContactMessageCreatedDomainEvent(Guid Id) : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
}