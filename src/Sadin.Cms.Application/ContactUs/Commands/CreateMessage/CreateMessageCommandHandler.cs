using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand, CreateMessageCommandResponse>
{
    private readonly IContactMessagesRepository _contactUsRepository;
    private readonly IUnitOfWork _uow;

    public CreateMessageCommandHandler(IContactMessagesRepository contactUsRepository,
        IUnitOfWork uow)
    {
        _contactUsRepository = contactUsRepository ?? throw new ArgumentNullException(nameof(contactUsRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
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
        
        _contactUsRepository.Add(message);
        await _uow.SaveChangesAsync(cancellationToken);
        
        return new CreateMessageCommandResponse(message);
    }
}