namespace Sadin.Cms.Shared.Exceptions.Base;

public abstract class KSEntityNotFoundException : KSException
{
    public KSEntityNotFoundException(Guid id)
        : base($"The entity with the id {id} was not found.")
    {
    }
}