using Project.Core.Entities;

namespace Project.Core.Services;
public interface IUserService : IGenericService<User>
{
    Task<User> GetUserByUserName(string email);
}
