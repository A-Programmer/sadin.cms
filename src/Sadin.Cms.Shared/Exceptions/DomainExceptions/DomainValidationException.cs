namespace Sadin.Cms.Shared.Exceptions.DomainExceptions;

public sealed class DomainValidationException : KSValidationException
{
    public DomainValidationException(string message)
        : base(message)
    {
        
    }
}