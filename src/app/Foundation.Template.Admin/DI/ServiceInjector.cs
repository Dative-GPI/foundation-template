using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Admin.Services;
using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.DI
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IActionService, ActionService>();

            services.AddScoped<IPermissionOrganisationTypeService, PermissionOrganisationTypeService>();
            services.AddScoped<IPermissionOrganisationService, PermissionOrganisationService>();
            services.AddScoped<IPermissionOrganisationCategoryService, PermissionOrganisationCategoryService>();
            services.AddScoped<IRoleOrganisationService, RoleOrganisationService>();

            services.AddScoped<IPermissionApplicationService, PermissionApplicationService>();
            services.AddScoped<IPermissionApplicationCategoryService, PermissionApplicationCategoryService>();
            services.AddScoped<IRoleApplicationService, RoleApplicationService>();

            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IApplicationTranslationService, ApplicationTranslationService>();

            return services;
        }
    }
}