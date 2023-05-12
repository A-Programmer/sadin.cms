using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Cms.Domain.Aggregates.ContactUs.Events;
using Sadin.Cms.Integration.Events.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Events;

public sealed class ContactMessageCreatedDomainEventHandler
    : IDomainEventHandler<ContactMessageCreatedDomainEvent>
{
    private readonly ContactMessageCreatedEventPublisher _contactMessageCreatedEventPublisher;
    private readonly IContactMessagesRepository _contactUsRepository;

    public ContactMessageCreatedDomainEventHandler(
        IContactMessagesRepository contactUsRepository,
        ContactMessageCreatedEventPublisher contactMessageCreatedEventPublisher)
    {
        _contactMessageCreatedEventPublisher = contactMessageCreatedEventPublisher;
        _contactUsRepository = contactUsRepository;
    }

    public async Task Handle(ContactMessageCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        ContactMessage? message = await _contactUsRepository.GetById(notification.Id, cancellationToken);
        if (message is null)
            return;
        
        ContactMessageCreatedEvent contactMessageCreatedEvent = new(message.FullName.Value, message.Email.Value);
        _contactMessageCreatedEventPublisher.Publish(contactMessageCreatedEvent);
    }
}