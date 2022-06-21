namespace Project.Core.DTOs.Users;

public class UserLoggedDto
{
    public string UserName { set; get; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}