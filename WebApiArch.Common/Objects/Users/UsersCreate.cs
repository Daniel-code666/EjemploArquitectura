namespace WebApi.Objects
{
    public class UsersCreate
    {
        public string username { get; set; } = string.Empty;
        public string user_dni { get; set; } = string.Empty;
        public string user_email { get; set; } = string.Empty;
        public string user_password { get; set; } = string.Empty;
    }
}
