namespace Sadin.Cms.Application.ContactUs.Commands.DeleteMessage;

public record DeleteContactMessageCommand(Guid Id) : ICommand<Guid>;