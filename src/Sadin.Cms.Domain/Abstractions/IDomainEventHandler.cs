using MediatR;
using Sadin.Common.Abstractions;

namespace Sadin.Cms.Domain.Abstractions;

public interface IDomainEventHandler<in T> : INotificationHandler<T>
    where T : DomainEvent
{

}
