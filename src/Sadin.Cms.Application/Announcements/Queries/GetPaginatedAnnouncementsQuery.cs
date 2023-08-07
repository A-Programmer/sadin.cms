using Sadin.Cms.Domain.Aggregates.Announcements;

namespace Sadin.Cms.Application.Announcements.Queries;

public sealed class GetPaginatedAnnouncementsQuery : Paginated, IQuery<PaginatedList<Announcement>>
{
    public GetPaginatedAnnouncementsQuery(int? pageNumber, int? pageSize, string searchString = "", string ordeBy = "", bool desc = false)
        : base(pageNumber, pageSize)
    {
        if (searchString.HasValue())
        {
            Where = x =>
                x.Title.Value.ToUpper().Contains(searchString.ToUpper()) ||
                x.Slug.Value.ToUpper().Contains(searchString.ToUpper()) ||
                x.Description.Value.ToUpper().Contains(searchString.ToUpper()) ||
                x.Content.Value.ToUpper().Contains(searchString.ToUpper());
        }
        OrderBy = ordeBy;
        Desc = desc;
    }

    public Expression<Func<Announcement, bool>>? Where { get; private set; }
    public string OrderBy { get; private set; }
    public bool Desc { get; private set; }
}