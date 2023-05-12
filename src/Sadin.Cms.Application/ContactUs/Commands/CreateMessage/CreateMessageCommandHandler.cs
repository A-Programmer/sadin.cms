using Sadin.Cms.Application.ContactUs.Events;
using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;
using Sadin.Cms.Integration.Events.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand, CreateMessageCommandResponse>
{
    private readonly IContactMessagesRepository _contactUsRepository;
    private readonly IUnitOfWork _uow;
    private readonly ContactMessageCreatedEventPublisher _contactMessageCreatedEventPublisher;

    public CreateMessageCommandHandler(IContactMessagesRepository contactUsRepository,
        IUnitOfWork uow,
        ContactMessageCreatedEventPublisher contactMessageCreatedEventPublisher)
    {
        _contactUsRepository = contactUsRepository ?? throw new ArgumentNullException(nameof(contactUsRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        _contactMessageCreatedEventPublisher = contactMessageCreatedEventPublisher;
    }

    public async Task<Result<CreateMessageCommandResponse>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        Result<FullName> fullNameResult = FullName.Create(request.FullName);
        Result<Email> emailResult = Email.Create(request.Email);
        Result<PhoneNumber> phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
        Result<Subject> subjectResult = Subject.Create(request.Subject);
        Result<Content> contentResult = Content.Create(request.Content);
        
        var message = ContactMessage
            .Create(
                Guid.NewGuid(),
                fullNameResult.Value,
                emailResult.Value,
                phoneNumberResult.Value,
                subjectResult.Value,
                contentResult.Value);
        
        _contactUsRepository.Insert(message);
        await _uow.SaveChangesAsync(cancellationToken);
        ContactMessageCreatedEvent contactMessageCreatedEvent = new(request.FullName, request.Email);
        _contactMessageCreatedEventPublisher.Publish(contactMessageCreatedEvent);
        
        return new CreateMessageCommandResponse(message);
    }
}