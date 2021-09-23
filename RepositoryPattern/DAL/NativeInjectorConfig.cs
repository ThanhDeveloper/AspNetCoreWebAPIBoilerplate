using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.DAL.Interfaces.UnitOfWork;
using RepositoryPattern.Data.UnitOfWork;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.Interfaces.IService;
using RepositoryPattern.Repositories;
using RepositoryPattern.Service;

namespace RepositoryPattern
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<ISongService, SongService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
