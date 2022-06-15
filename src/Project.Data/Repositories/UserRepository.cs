using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using Project.Core.Repositories;

namespace Project.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
        
        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(b => b.UserName.Equals(userName));
        }
    }
}
