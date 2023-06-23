using System.Linq.Expressions;
using Sadin.Common.Pagination;

namespace Sadin.Cms.Domain.Aggregates.ContactUs;

public interface IContactMessagesRepository
{
    void Add(ContactMessage message);
    void Delete(ContactMessage message);
    Task<ContactMessage?> GetById(Guid id, CancellationToken cancellationToken);

    Task<PaginatedList<ContactMessage>> GetPagedAsync(int pageIndex, int pageSize,
        Expression<Func<ContactMessage, bool>>? where = null, string orderBy = "", bool desc = false,
        CancellationToken cancellationToken = default);
}