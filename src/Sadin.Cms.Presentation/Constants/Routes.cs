namespace Sadin.Cms.Presentation.Constants;

public static class Routes
{
    public const string BaseRootAddress = "api/[controller]";
    public const string SignIn = "";
    public const string SignOut = "";
    public const string SignUp = "";
    public static class ContactUs
    {
        public static class Get
        {
            public const string GetAll = "";
            public const string GetById = "{id}";
        }
        public static class Post
        {
            public const string Add = "";
        }
        public static class Delete
        {
            public const string Remove = "{id}";
        }
        public static class Edit
        {
            public const string Update = "";
            public const string MarkAsRead = "{id}/mark-as-read";
            public const string MarkAsUnread = "{id}/mark-as-unread";
            public const string ChangeStatus = "{id}/change-status";
        }
    }
}