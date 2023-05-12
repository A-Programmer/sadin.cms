namespace Sadin.Cms.Application.ContactUs.Events;

public interface IIntegrationEventPublisher
{
    public void Publish(IntegrationEvent @event);
}