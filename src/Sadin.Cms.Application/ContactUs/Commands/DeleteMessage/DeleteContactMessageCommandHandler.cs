using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Common.Errors;

namespace Sadin.Cms.Application.ContactUs.Commands.DeleteMessage;

public sealed class DeleteContactMessageCommandHandler
    : ICommandHandler<DeleteContactMessageCommand, Guid>
{
    private readonly IContactMessagesRepository _contactMessagesRepository;
    private readonly IUnitOfWork _uow;

    public DeleteContactMessageCommandHandler(IContactMessagesRepository contactMessagesRepository, IUnitOfWork uow)
    {
        _contactMessagesRepository = contactMessagesRepository ??
                                     throw new ArgumentNullException(nameof(contactMessagesRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Result<Guid>> Handle(DeleteContactMessageCommand request, CancellationToken cancellationToken)
    {
        ContactMessage message = await _contactMessagesRepository.GetById(request.Id, cancellationToken);
        if (message is null)
            return Result.Failure<Guid>(new Error(
                "ContactMessage.Delete",
                $"Message with id {request.Id} could not be found."));
        _contactMessagesRepository.Delete(message);
        await _uow.SaveChangesAsync(cancellationToken);
        
        return Result.Success(request.Id);
    }
}