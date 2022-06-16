using Project.Core.DTOs.Users;
using Project.Core.Entities;

namespace Project.Core.Services;
public interface IUserService : IGenericService<User>
{

    Task<User> GetByUserName(string userName);
}
