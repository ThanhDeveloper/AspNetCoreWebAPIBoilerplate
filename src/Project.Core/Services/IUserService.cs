using Project.Core.DTOs.Users;
using Project.Core.Entities;

namespace Project.Core.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task Create(UserCreateDto userCreateDto);
        Task<UserLoggedDto> Authenticate(UserLoginDto userLoginDto);
    }
}
