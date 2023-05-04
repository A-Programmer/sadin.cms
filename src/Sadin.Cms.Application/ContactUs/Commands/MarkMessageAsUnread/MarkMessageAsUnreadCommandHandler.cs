using Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsRead;
using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsUnread;

public sealed class MarkMessageAsUnreadCommandHandler : ICommandHandler<MarkMessageAsUnreadCommand>
{
    private readonly IContactMessagesRepository _contactMessagesRepository;
    private readonly IUnitOfWork _uow;

    public MarkMessageAsUnreadCommandHandler(IContactMessagesRepository contactMessagesRepository, IUnitOfWork uow)
    {
        _contactMessagesRepository = contactMessagesRepository ??
                                     throw new ArgumentNullException(nameof(contactMessagesRepository));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Result> Handle(MarkMessageAsUnreadCommand request, CancellationToken cancellationToken)
    {
        ContactMessage message = await _contactMessagesRepository.GetById(request.Id, cancellationToken);
        
        message.MarkAsUnChecked();

        await _uow.SaveChangesAsync(cancellationToken);
        
        return Result.Success(request.Id);
    }
}