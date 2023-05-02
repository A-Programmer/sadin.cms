namespace Sadin.Cms.Domain.Aggregates.ContactUs;

public interface IContactMessagesRepository
{
    void Insert(ContactMessage message);
    void Delete(ContactMessage message);
    Task<ContactMessage?> GetById(Guid id, CancellationToken cancellationToken);
}