using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuleWayECommerce.Persistence.AppDbContext;

namespace RuleWayECommerce.WebApi.WebApiExtensions
{
    public static class MigrationExtensions
    {
        public static async Task ApplyMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}