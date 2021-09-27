using AutoMapper;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;

namespace RepositoryPattern.DAL.Services
{
    public class ServiceMaster 
    {
        public static IConfiguration Confuguration;
        protected static IMapper Mapper;
        protected static IUnitOfWork UnitOfWork;
    }
}
