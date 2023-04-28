namespace Sadin.Cms.Domain.Abstractions;

public interface IEmailSender
{
    Task SendEmail(string receiver, string title, string content);
}