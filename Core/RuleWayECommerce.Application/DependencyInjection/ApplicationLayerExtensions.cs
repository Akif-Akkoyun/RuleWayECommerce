using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RuleWayECommerce.Application.DependencyInjection
{
    public static class ApplicationLayerExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationLayerExtensions).Assembly);

            return services;
        }
    }
}