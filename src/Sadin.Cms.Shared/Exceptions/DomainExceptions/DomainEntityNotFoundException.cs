namespace Sadin.Cms.Shared.Exceptions.DomainExceptions;

public class DomainEntityNotFoundException : KSEntityNotFoundException
{
    public DomainEntityNotFoundException(Guid id) : base(id)
    {
    }
}