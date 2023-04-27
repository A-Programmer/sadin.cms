namespace Sadin.Cms.Domain.Aggregates.ContactUs;

public interface IContactMessagesRepository
{
    void Insert(ContactMessage message);
}