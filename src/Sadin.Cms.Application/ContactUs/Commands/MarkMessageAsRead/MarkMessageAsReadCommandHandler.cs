using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsRead;

public sealed class MarkMessageAsReadCommandHandler : ICommandHandler<MarkMessageAsReadCommand>
{
    private readonly IContactMessagesRepository _contactMessagesRepository;
    private readonly IUnitOfWork _uow;

    public MarkMessageAsReadCommandHandler(IContactMessagesRepository contactMessagesRepository, IUnitOfWork uow)
    {
        _contactMessagesRepository = contactMessagesRepository ??
                                     throw new ArgumentNullException(nameof(contactMessagesRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Result> Handle(MarkMessageAsReadCommand request, CancellationToken cancellationToken)
    {
        ContactMessage message = await _contactMessagesRepository.GetById(request.Id, cancellationToken);
        
        message.MarkAsChecked();

        await _uow.SaveChangesAsync(cancellationToken);
        
        return Result.Success(request.Id);
    }
}