namespace Sadin.Cms.Shared.Exceptions.Base;

public abstract class KSException : Exception
{
    protected KSException()
    {
    }

    protected KSException(string message)
        : base(message)
    {
    }

    protected KSException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}