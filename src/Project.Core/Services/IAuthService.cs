using Project.Core.DTOs.Users;
using Project.Core.Entities;

namespace Project.Core.Services;
public interface IAuthService
{
    Task Register(UserRegisterDto userRegisterDto);
    Task<UserLoggedDto> Authenticate(UserLoginDto userLoginDto);
    Task<Dictionary<string, string>> RefreshToken(int userId);
    bool CheckExpires(string refreshToken);
}