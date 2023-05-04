using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Queries.GetAllContactMessages;

public sealed class GetAllContactMessagesResponse
{
    public GetAllContactMessagesResponse(ContactMessage message)
    {
        Id = message.Id;
        FullName = message.FullName.Value;
        Email = message.Email.Value;
        PhoneNumber = message.PhoneNumber.Value;
        Subject = message.Subject.Value;
        Content = message.Subject.Value;
        IsChecked = message.IsChecked;
        IsDeleted = message.IsDeleted;
        CreatedBy = message.CreatedBy;
        CreatedOn = message.CreatedOnUtc;
        ModifiedBy = message.ModifiedBy;
        ModifiedOn = message.ModifiedOnUtc;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Subject { get; private set; }
    public string Content { get; private set; }
    public bool IsChecked { get; private set; }
    public bool IsDeleted { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTimeOffset? ModifiedOn { get; private set; }
}