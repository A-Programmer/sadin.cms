namespace Sadin.Cms.Application.Abstractions;

public interface IEmailSender
{
    Task SendEmail(string receiver, string title, string content);
}