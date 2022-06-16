using Project.Core.DTOs.Users;

namespace Project.Core.Services;
public interface IAuthService
{
    Task Register(UserRegisterDto userRegisterDto);
    Task<UserLoggedDto> Authenticate(UserLoginDto userLoginDto);
}