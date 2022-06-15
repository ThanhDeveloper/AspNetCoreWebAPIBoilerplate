using Project.Core.Entities;

namespace Project.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserName(string userName);
    }
}