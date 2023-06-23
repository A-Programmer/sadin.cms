using System.Linq.Expressions;
using Sadin.Common.Pagination;

namespace Sadin.Cms.Domain.Aggregates.Categories;

public interface ICategoriesRepository
{
    Category Add(Category category);
    
    Guid Delete(Guid id);
    
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<List<Category>> GetAllAsync();
    
    Task<List<PaginatedList<Category>>> GetPagedTagAsync(int pageIndex, int pageSize,
        Expression<Func<Category, bool>>? where = null, string orderBy = "", bool desc = false,
        CancellationToken cancellationToken = default);
}