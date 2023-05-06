namespace Sadin.Cms.Domain.Aggregates.ContactUs.Events;

public sealed record ContactMessageCreatedDomainEvent(Guid Id)
    : DomainEvent(Id, DateTimeOffset.Now)
{
    public string ContactMessageSerialized { get; set; }
}