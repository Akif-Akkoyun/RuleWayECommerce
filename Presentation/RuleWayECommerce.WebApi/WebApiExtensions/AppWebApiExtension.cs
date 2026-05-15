using RuleWayECommerce.Persistence.Extensions;

namespace RuleWayECommerce.WebApi.WebApiExtensions
{
    public static class AppWebApiExtension
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var connectionString =
                config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found.");

            services.AddPersistence(config, connectionString);

            return services;
        }
    }
}
