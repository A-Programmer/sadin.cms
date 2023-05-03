using Microsoft.AspNetCore.Http;

namespace Sadin.Cms.Infrastructure.Authentication;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

    public IUserSession GetCurrentUser()
    {
        if (_httpContextAccessor?.HttpContext is null)
        {
            return UserSession.Create(false, null);
        }

        IUserSession currentUser = UserSession.Create(
            _httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false,
            _httpContextAccessor.HttpContext.User.Identity?.Name);

        return currentUser;
    }
}