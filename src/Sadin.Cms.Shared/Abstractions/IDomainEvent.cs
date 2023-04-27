namespace Sadin.Cms.Shared.Abstractions;
public interface IDomainEvent : INotification
{
    DateTimeOffset OccurredOn { get; }
}