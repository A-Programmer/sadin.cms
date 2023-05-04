namespace Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsRead;

public record MarkMessageAsReadCommand(Guid Id) : ICommand;