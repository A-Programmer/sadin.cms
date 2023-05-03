namespace Sadin.Cms.Domain.Abstractions;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}