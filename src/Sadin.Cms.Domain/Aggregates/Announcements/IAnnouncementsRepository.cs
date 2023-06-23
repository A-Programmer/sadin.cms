using System.Linq.Expressions;
using Sadin.Common.Pagination;

namespace Sadin.Cms.Domain.Aggregates.Announcements;

public interface IAnnouncementsRepository
{
    Announcement Add(Announcement announcement);
    
    Guid Delete(Guid id);
    
    Task<Announcement?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Announcement>> GetAllAsync();
    
    Task<List<PaginatedList<Announcement>>> GetPagedAsync(int pageIndex, int pageSize,
        Expression<Func<Announcement, bool>>? where = null, string orderBy = "", bool desc = false,
        CancellationToken cancellationToken = default);
}