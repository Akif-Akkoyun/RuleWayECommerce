using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuleWayECommerce.Application.DependencyInjection;
using RuleWayECommerce.Application.Interfaces;
using RuleWayECommerce.Persistence.AppDbContext;
using RuleWayECommerce.Persistence.Repositories;


namespace RuleWayECommerce.Persistence.Extensions
{
    public static class PersistenceLayerExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<DbContext ,ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddApplication();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
