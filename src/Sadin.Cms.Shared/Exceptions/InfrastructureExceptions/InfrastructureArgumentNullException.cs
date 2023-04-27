namespace Sadin.Cms.Shared.Exceptions.InfrastructureExceptions;

public sealed class InfrastructureArgumentNullException : KSArgumentNullException
{
    public InfrastructureArgumentNullException(string paramName) : base(paramName)
    {
    }
}