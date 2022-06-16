using Project.Core.DTOs.Users;

namespace Project.Core.Services;
public interface IAuthService
{
    Task Register(UserCreateDto userCreateDto);
    Task<UserLoggedDto> Authenticate(UserLoginDto userLoginDto);
}