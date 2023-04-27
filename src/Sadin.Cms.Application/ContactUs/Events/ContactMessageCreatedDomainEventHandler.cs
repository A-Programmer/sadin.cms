using Sadin.Cms.Application.Abstractions;
using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Events;

public sealed class ContactMessageCreatedDomainEventHandler
    : IDomainEventHandler<ContactMessageCreatedDomainEvent>
{
    private readonly IEmailSender _emailSender;
    private readonly IContactMessagesRepository _contactUsRepository;

    public ContactMessageCreatedDomainEventHandler(IEmailSender emailSender, IContactMessagesRepository contactUsRepository)
    {
        _emailSender = emailSender;
        _contactUsRepository = contactUsRepository;
    }

    public async Task Handle(ContactMessageCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        ContactMessage? message = await _contactUsRepository.GetById(notification.Id, cancellationToken);
        if (message is null)
            return;
        await _emailSender.SendEmail(
            message.Email.Value,
            "Hey there, we got your message.",
            "Hi there, we got your message, we will response to your message ASAP");
    }
}