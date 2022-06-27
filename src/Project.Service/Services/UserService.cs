using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using Project.Core.Repositories;
using Project.Core.Services;
using Project.Core.UnitOfWorks;
using Project.Service.Common.Exceptions;

namespace Project.Service.Services;

public class UserService : Service<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByUserName(string userName)
    {
        var user =  await _userRepository.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        return user;
    }
    
}
