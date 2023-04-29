namespace Sadin.Cms.Domain.Events.ContactUsEvents;

public sealed record ContactMessageCreatedDomainEvent(Guid Id)
    : DomainEvent(Id, DateTimeOffset.Now)
{
    public string ContactMessageSerialized { get; set; }
}