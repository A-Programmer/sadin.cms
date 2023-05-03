namespace Sadin.Cms.Domain.Abstractions;

public interface IUserSession
{
    string UserName { get; }

    bool IsAuthenticated { get; }
}