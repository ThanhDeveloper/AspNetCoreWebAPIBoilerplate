using AutoMapper;
using Project.Core.DTOs.Customers;
using Project.Core.DTOs.Users;
using Project.Core.Entities;

namespace Project.Service.Mapping;
public class MapProfile : Profile
{
    public MapProfile() 
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerCreateDto, Customer >();
        CreateMap<CustomerUpdateDto, Customer>();
        
        CreateMap<UserCreateDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<User, UserLoggedDto>();
    }
}
