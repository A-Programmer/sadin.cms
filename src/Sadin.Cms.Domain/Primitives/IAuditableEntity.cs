namespace Sadin.Cms.Domain.Primitives;

public interface IAuditableEntity
{
    /// <summary>
    /// Gets the created on date and time in UTC format.
    /// </summary>
    DateTimeOffset CreatedOnUtc { get; }

    /// <summary>
    /// Gets the modified on date and time in UTC format.
    /// </summary>
    DateTimeOffset? ModifiedOnUtc { get; }
}