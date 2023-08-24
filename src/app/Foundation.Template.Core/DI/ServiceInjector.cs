using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Core.Services;
using Foundation.Template.Core.Abstractions;

namespace Foundation.Template.Core.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IActionService, ActionService>();
            
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleOrganisationService, RoleOrganisationService>();

            return services;
        }
    }
}