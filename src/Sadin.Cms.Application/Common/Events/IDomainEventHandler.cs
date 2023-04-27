namespace Sadin.Cms.Application.Common.Events;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{

}
