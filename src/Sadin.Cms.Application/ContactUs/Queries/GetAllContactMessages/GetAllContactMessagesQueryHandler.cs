using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Common.Errors;

namespace Sadin.Cms.Application.ContactUs.Queries.GetAllContactMessages;

public sealed class GetAllContactMessagesQueryHandler : IQueryHandler<GetAllContactMessagesQuery, PaginatedList<GetAllContactMessagesResponse>>
{
    private readonly IContactMessagesRepository _contactMessagesRepository;

    public GetAllContactMessagesQueryHandler(IUnitOfWork uow, IContactMessagesRepository contactMessagesRepository)
        => _contactMessagesRepository = contactMessagesRepository ?? throw new ArgumentNullException(nameof(contactMessagesRepository));

    public async Task<Result<PaginatedList<GetAllContactMessagesResponse>>> Handle(GetAllContactMessagesQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = await _contactMessagesRepository.GetPagedAsync(
            request.PageIndex,
            request.PageSize,
            request.Where,
            request.OrderBy,
            request.Desc);
        
        var result = new PaginatedList<GetAllContactMessagesResponse>(
            pagedItems.Select(x => new GetAllContactMessagesResponse(x)).ToList(),
            pagedItems.TotalItems,
            pagedItems.PageIndex,
            request.PageSize);
        
        
        return Result<PaginatedList<GetAllContactMessagesResponse>>.CreatePaginatedResult(result, true, Error.None, pagedItems.PageIndex,
            pagedItems.TotalPages, pagedItems.TotalItems, pagedItems.ShowPagination);
        
    }
}