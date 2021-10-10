using AspNetCoreTemplate.DAL.Interfaces.IService;
using AspNetCoreTemplate.DAL.Interfaces.IUnitOfWork;
using AspNetCoreTemplate.DAL.Services;
using AspNetCoreTemplate.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreTemplate.DAL.Interfaces.IRepository;
using AspNetCoreTemplate.DAL.Repositories;

namespace AspNetCoreTemplate.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
