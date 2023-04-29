using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;

public sealed class GetContactMessageByIdQueryHandler : IQueryHandler<GetContactMessageByIdQuery, ContactMessageResponse>
{
    private readonly IContactMessagesRepository _contactMessagesRepository;

    public GetContactMessageByIdQueryHandler(IContactMessagesRepository contactMessagesRepository)
        => _contactMessagesRepository = contactMessagesRepository;

    public async Task<Result<ContactMessageResponse>> Handle(
        GetContactMessageByIdQuery request,
        CancellationToken cancellationToken)
    {
        ContactMessage message = await _contactMessagesRepository
            .GetById(request.Id, cancellationToken);
        
        return new ContactMessageResponse(message);
    }
}