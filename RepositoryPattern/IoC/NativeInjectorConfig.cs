using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.DAL.Interfaces.IService;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;
using RepositoryPattern.DAL.Repositories;
using RepositoryPattern.DAL.Services;
using RepositoryPattern.DAL.UnitOfWork;

namespace RepositoryPattern.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ISongService, SongService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
