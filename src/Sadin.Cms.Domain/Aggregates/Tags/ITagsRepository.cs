using System.Linq.Expressions;
using Sadin.Common.Pagination;

namespace Sadin.Cms.Domain.Aggregates.Tags;

public interface ITagsRepository
{
    Tag Add(Tag tag);
    
    Guid Delete(Guid id);
    
    Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Tag>> GetAllAsync();
    
    Task<List<PaginatedList<Tag>>> GetPagedTagAsync(int pageIndex, int pageSize,
        Expression<Func<Tag, bool>>? where = null, string orderBy = "", bool desc = false,
        CancellationToken cancellationToken = default);
}