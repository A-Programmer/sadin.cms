using Microsoft.Extensions.Logging;
using Sadin.Cms.Domain.Abstractions;

namespace Sadin.Cms.Infrastructure.EmailServices;

public sealed class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
        =>_logger = logger;

    public async Task SendEmail(string receiver, string title, string content)
    {
        _logger.LogInformation("{Receiver} \n\n\n\n{Title} \n\n\n\n{Content}", receiver, title, content);
    }
}