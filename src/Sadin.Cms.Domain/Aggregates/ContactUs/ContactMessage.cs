using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;
using ContactMessageCreatedDomainEvent = Sadin.Cms.Domain.Aggregates.ContactUs.Events.ContactMessageCreatedDomainEvent;

namespace Sadin.Cms.Domain.Aggregates.ContactUs;

public sealed class ContactMessage : AggregateRoot, IAuditableEntity
{
    private ContactMessage(Guid id,
        FullName fullName, Email email, PhoneNumber phoneNumber, Subject subject, Content content, bool isChecked = false)
        : base(id)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Subject = subject;
        Content = content;
        IsChecked = isChecked;
    }

    public static ContactMessage Create(Guid id, FullName fullName, Email email, PhoneNumber phoneNumber, Subject subject, Content content)
    {
        ContactMessage contactMessage = new(id, fullName, email, phoneNumber, subject, content);
        contactMessage.RaiseDomainEvent(new ContactMessageCreatedDomainEvent(id));
        return contactMessage;
    }

    public void MarkAsChecked()
        => IsChecked = true;
    
    public void MarkAsUnChecked()
        => IsChecked = false;

    public void ChangeCheckStatus()
        => IsChecked = !IsChecked;

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
}