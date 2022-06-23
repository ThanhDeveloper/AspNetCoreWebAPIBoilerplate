using AutoMapper;
using Project.Core.DTOs.Users;
using Project.Core.Entities;

namespace Project.Service.Mapping.Users;

public class UserProfile: Profile
{
    public UserProfile() 
    {
        CreateMap<UserRegisterDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<User, UserLoggedDto>();
    }
}
