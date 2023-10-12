using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class MiddlewareInjector
    {
        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<PermissionAdminsMiddleware>();
            
            return services;
        }
    }
}