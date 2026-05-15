using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuleWayECommerce.Persistence.AppDbContext;


namespace RuleWayECommerce.Persistence.Extensions
{
    public static class PersistenceLayerExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<DbContext ,ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
