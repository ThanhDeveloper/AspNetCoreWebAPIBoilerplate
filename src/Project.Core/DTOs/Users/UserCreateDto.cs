namespace Project.Core.DTOs.Users;

public class UserCreateDto
{
    public string UserName { set; get; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
}