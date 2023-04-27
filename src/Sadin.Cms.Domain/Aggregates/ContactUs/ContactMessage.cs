using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;
using Sadin.Cms.Domain.Events.ContactUsEvents;

namespace Sadin.Cms.Domain.Aggregates.ContactUs;

public sealed class ContactMessage : AggregateRoot
{
    private ContactMessage(Guid id,
        FullName fullName, Email email, PhoneNumber phoneNumber, Subject subject, Content content,
        DateTimeOffset createdDate, bool isChecked = false, DateTimeOffset? updatedDate = null)
        : base(id)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Subject = subject;
        Content = content;
        IsChecked = isChecked;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static ContactMessage Create(Guid id, FullName fullName, Email email, PhoneNumber phoneNumber, Subject subject, Content content)
    {
        ContactMessage contactMessage = new(id, fullName, email, phoneNumber, subject, content, DateTimeOffset.Now);
        contactMessage.RaiseDomainEvent(new ContactMessageCreatedDomainEvent(id));
        return contactMessage;
    }

    public void MarkAsChecked()
    {
        UpdatedDate = DateTimeOffset.Now;
        IsChecked = true;
    }
    public void MarkAsUnChecked()
    {
        UpdatedDate = DateTimeOffset.Now;
        IsChecked = false;
    }

    public void ChangeCheckStatus()
    {
        UpdatedDate = DateTimeOffset.Now;
        IsChecked = !IsChecked;
    }

    protected ContactMessage(Guid id)
        : base(id)
    {
    }

    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Subject Subject { get; private set; }
    public Content Content { get; private set; }
    public bool IsChecked { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }
    public DateTimeOffset? UpdatedDate { get; private set; }
}