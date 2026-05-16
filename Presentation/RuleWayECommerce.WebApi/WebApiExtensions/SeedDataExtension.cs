using RuleWayECommerce.Persistence.AppDbContext;
using RuleWayECommerce.Persistence.SeedData;

namespace RuleWayECommerce.WebApi.WebApiExtensions
{
    public static class SeedDataExtension
    {
        public static async Task SeedDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await DatabaseSeeder.SeedAsync(context);
        }
    }
}