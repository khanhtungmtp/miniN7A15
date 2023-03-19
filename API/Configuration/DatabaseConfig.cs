using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Configuration
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("strConnect")));
        }
    }
}