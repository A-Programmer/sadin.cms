namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed record CreateMessageCommand(string FullName, string Email, string PhoneNumber, string Subject, string Content)
    : ICommand<Result<CreateMessageCommandResponse>>;