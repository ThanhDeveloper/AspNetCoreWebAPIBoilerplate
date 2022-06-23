using AutoMapper;
using Project.Core.DTOs.Customers;
using Project.Core.Entities;

namespace Project.Service.Mapping.Customers;

public class CustomerProfile : Profile
{
    public CustomerProfile() 
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerCreateDto, Customer >();
        CreateMap<CustomerUpdateDto, Customer>();
    }
}
