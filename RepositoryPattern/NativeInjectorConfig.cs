using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Data.Repositories;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISongRepository, SongRepository>();
        }
    }
}
