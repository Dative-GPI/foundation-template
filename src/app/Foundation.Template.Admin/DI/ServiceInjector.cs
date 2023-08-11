using Microsoft.Extensions.DependencyInjection;
using Foundation.Template.Admin.Services;
using Foundation.Template.Admin.Interfaces;

namespace Foundation.Template.Admin.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<IOrganisationTypePermissionService, OrganisationTypePermissionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionCategoryService, PermissionCategoryService>();
            services.AddScoped<IRoleOrganisationService, RoleOrganisationService>();

            services.AddScoped<IPermissionAdminService, PermissionAdminService>();
            services.AddScoped<IPermissionAdminCategoryService, PermissionAdminCategoryService>();
            services.AddScoped<IRoleAdminService, RoleAdminService>();

            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IApplicationTranslationService, ApplicationTranslationService>();

            return services;
        }
    }
}