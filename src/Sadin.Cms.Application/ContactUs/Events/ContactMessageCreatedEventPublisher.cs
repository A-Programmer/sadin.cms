using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Sadin.Cms.Application.Messaging.Models;
using Sadin.Cms.Integration.Events.ContactUs;

namespace Sadin.Cms.Application.ContactUs.Events;

// TODO : Currently, I am using simplest way to publish events, please refactor and improve considering these items:
// 1. Currently, it is working like fire and forget, it doesn't have any retry policy.
// 2. Is it possible to implement idempotency for these kind of events same as DomainEvents?

// TODO : Check if I could use another Message Bus like Kafka instead of RabbitMQ (Of course, I don't need to change the Message Bus
// but it's better to see how it would be hard to change the Message Bus)

// TODO : Is it possible to make the publisher better? Like having an interface or abstract class for subscribe/unsubscribe and inherit from them?
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
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.ExchangeDeclare(exchange: "trigger",
                type: ExchangeType.Fanout);
        }
        catch (Exception e)
        {
            // TODO : Log the exception instead of Console.WriteLine.
            Console.WriteLine("Could not connect to the MessageBus ===> {0}", e.Message);
        }
    }

    public void Publish(ContactMessageCreatedEvent integrationEvent)
    {
        
        var message = JsonSerializer.Serialize(integrationEvent);
    
        if (_connection.IsOpen)
        {
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
                // TODO : Log the exception instead of Console.WriteLine
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