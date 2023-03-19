using API._Repositories;
using API._Services.Interfaces;
using API._Services.Services;

namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDepedencyInjectionConfig(this IServiceCollection services)
        {
            // add repostory
            services.AddScoped<IRepositoryAccessor, RepositoryAccessor>();
            // add services
            services.AddScoped<IProductServices, ProductServices>();
        }
    }
}