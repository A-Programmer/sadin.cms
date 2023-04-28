namespace Sadin.Cms.Domain.Events.ContactUsEvents;

public sealed class ContactMessageCreatedDomainEvent : IDomainEvent
{
    public Guid Id { get; set; }
    public string ContactMessageSerialized { get; set; }
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
}