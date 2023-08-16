using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Shell.Handlers;

namespace Foundation.Template.Shell.DI
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