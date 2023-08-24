using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Core.Handlers;

namespace Foundation.Template.Core.DI
{
    public static class MiddlewareInjector
    {
        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<PermissionsMiddleware>();
            
            return services;
        }
    }
}