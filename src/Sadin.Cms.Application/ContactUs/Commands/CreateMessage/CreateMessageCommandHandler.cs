using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;
using Sadin.Cms.Shared.Result;

namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand, Result<CreateMessageCommandResponse>>
{
    private readonly IContactMessagesRepository _contactUsRepository;
    private readonly IUnitOfWork _uow;

    public CreateMessageCommandHandler(IContactMessagesRepository contactUsRepository, IUnitOfWork uow)
    {
        _contactUsRepository = contactUsRepository ?? throw new ArgumentNullException(nameof(contactUsRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Result<CreateMessageCommandResponse>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = ContactMessage
            .Create(
                Guid.NewGuid(),
                FullName.Create(request.FullName),
                Email.Create(request.Email),
                PhoneNumber.Create(request.PhoneNumber),
                Subject.Create(request.Subject),
                Content.Create(request.Content));
        
        _contactUsRepository.Insert(message);
        await _uow.SaveChangesAsync(cancellationToken);
        return new CreateMessageCommandResponse(message);
    }
}