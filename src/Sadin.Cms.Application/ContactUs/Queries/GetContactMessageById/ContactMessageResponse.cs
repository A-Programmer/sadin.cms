using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;

public sealed class ContactMessageResponse
{
    public ContactMessageResponse(ContactMessage message)
    {
        Id = message.Id;
        FullName = message.FullName.Value;
        Email = message.Email.Value;
        PhoneNumber = message.PhoneNumber.Value;
        Subject = message.Subject.Value;
        Content = message.Content.Value;
        CreatedOnUtc = message.CreatedOnUtc;
        ModifiedOnUtc = message.ModifiedOnUtc;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Subject { get; private set; }
    public string Content { get; private set; }
    public DateTimeOffset CreatedOnUtc { get; private set; }
    public DateTimeOffset? ModifiedOnUtc { get; private set; }
}