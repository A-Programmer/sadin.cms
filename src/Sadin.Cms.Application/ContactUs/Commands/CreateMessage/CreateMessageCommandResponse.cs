using Sadin.Cms.Domain.Aggregates.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed class CreateMessageCommandResponse
{
    public CreateMessageCommandResponse(ContactMessage message)
    {
        Id = message.Id;
        FullName = message.FullName.Value;
        Email = message.Email.Value;
        PhoneNumber = message.PhoneNumber.Value;
        Subject = message.Subject.Value;
        Content = message.Content.Value;
        IsChecked = message.IsChecked;
        CreatedOnUtc = message.CreatedOnUtc;
    }

    public Guid Id { get; private init; }
    public string FullName { get; private init; }
    public string Email { get; private init; }
    public string PhoneNumber { get; private init; }
    public string Subject { get; private init; }
    public string Content { get; private init; }
    public bool IsChecked { get; private init; }
    public DateTimeOffset CreatedOnUtc { get; private init; }
}