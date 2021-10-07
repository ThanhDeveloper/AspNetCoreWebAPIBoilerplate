using AutoMapper;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;

namespace RepositoryPattern.DAL.Services
{
    public class BaseService 
    {
        public IConfiguration Configuration;
        public IMapper Mapper;
        public IUnitOfWork UnitOfWork;
    }
}
