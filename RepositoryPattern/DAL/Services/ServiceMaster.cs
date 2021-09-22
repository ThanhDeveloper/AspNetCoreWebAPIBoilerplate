using AutoMapper;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DAL.Interfaces.UnitOfWork;
using RepositoryPattern.Data.UnitOfWork;

namespace RepositoryPattern.DAL.Services
{
    public class ServiceMaster 
    {
        public static IConfigurationRoot Confuguration;
        public static IMapper Mapper;
        public static IUnitOfWork UnitOfWork;
    }
}
