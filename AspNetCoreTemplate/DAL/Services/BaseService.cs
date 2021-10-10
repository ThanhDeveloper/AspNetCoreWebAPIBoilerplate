using AspNetCoreTemplate.DAL.Interfaces.IUnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreTemplate.DAL.Services
{
    public class BaseService 
    {
        public IConfiguration Configuration;
        public IMapper Mapper;
        public IUnitOfWork UnitOfWork;
    }
}
