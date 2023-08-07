using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Queries.GetAllContactMessages;

public sealed class GetPaginatedContactMessagesQuery : Paginated, IQuery<PaginatedList<GetAllContactMessagesResponse>>
{
    public GetPaginatedContactMessagesQuery(int? pageNumber, int? pageSize, string searchString = "", string ordeBy = "", bool desc = false)
        : base(pageNumber, pageSize)
    {
        if(searchString.HasValue())
        {
            Where = x =>
                x.FullName.Value.ToLower().Contains(searchString.ToLower()) ||
                x.Email.Value.ToLower().Contains(searchString.ToLower()) ||
                x.PhoneNumber.Value.ToLower().Contains(searchString.ToLower()) ||
                x.Subject.Value.ToLower().Contains(searchString.ToLower()) ||
                x.Content.Value.ToLower().Contains(searchString.ToLower());
        }
        OrderBy = ordeBy;
        Desc = desc;
    }

    public Expression<Func<ContactMessage, bool>>? Where { get; private set; }
    public string OrderBy { get; private set; }
    public bool Desc { get; private set; }
}