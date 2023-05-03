namespace Sadin.Cms.Infrastructure.Authentication;

public class UserSession : IUserSession
{
    public UserSession()
    {
        
    }
    public UserSession(bool isAuthenticated, string userName)
    {
        UserName = userName;
        IsAuthenticated = isAuthenticated;
    }

    public static IUserSession Create(bool isAuthenticated, string? userName)
    {
        return new UserSession(isAuthenticated, userName ?? "Not_Registered");
    }
    public string UserName { get; }

    public bool IsAuthenticated { get; }

}