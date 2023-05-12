using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Sadin.Cms.Application.Messaging.Models;
using Sadin.Cms.Integration.Events.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Events;

public sealed class ContactMessageCreatedEventPublisher : IDisposable
{
    private readonly MessagingOptions _messagingOptions;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public ContactMessageCreatedEventPublisher(IOptions<MessagingOptions> options)
    {
        _messagingOptions = options.Value;
        
        var factory = new ConnectionFactory
        {
            HostName = _messagingOptions.HostName,
            Port = _messagingOptions.HostPort,
            UserName = _messagingOptions.UserName,
            Password = _messagingOptions.Password
        };

        try
        {
            Console.WriteLine("\n\n\n Connecting to the MessageBus \n\n\n\n");
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.ExchangeDeclare(exchange: "trigger",
                type: ExchangeType.Fanout);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not connect to the MessageBus ===> {0}", e.Message);
        }
    }

    public void Publish(ContactMessageCreatedEvent integrationEvent)
    {
        
        var message = JsonSerializer.Serialize(integrationEvent);
    
        if (_connection.IsOpen)
        {
            Console.WriteLine("\n\n\n\n publishing event ...\n\n\n\n");
            var body = Encoding.UTF8.GetBytes(message);
            try
            {
                _channel.BasicPublish(exchange: "trigger",
                    routingKey: "",
                    basicProperties: null,
                    body: body);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n\n\n Could not send the message ==> \n\n {0} \n\n\n\n\n", e.Message);
            }
        }
    }

    public void Dispose()
    {
        if (_connection.IsOpen)
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}