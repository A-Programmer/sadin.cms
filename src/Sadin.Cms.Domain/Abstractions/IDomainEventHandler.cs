using MediatR;

namespace Sadin.Cms.Domain.Abstractions;

public interface IDomainEventHandler<in T> : INotificationHandler<T>
    where T : DomainEvent
{

}
