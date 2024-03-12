using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Bones.Flow;

using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Admin.Providers;
using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddAdminTemplate(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            services.AddCrossCutting(configuration);

            services.AddScoped<RequestContextProvider>();
            services.AddScoped<IRequestContextProvider>(sp
                => sp.GetRequiredService<RequestContextProvider>());

            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();

            services.AddPermissions();
            services.AddPermissionOrganisationCategories();
            services.AddPermissionOrganisationTypes();
            services.AddRolePermissionOrganisation();

            services.AddPermissionApplications();
            services.AddPermissionApplicationCategories();
            services.AddRoleApplication();

            services.AddTranslations();
            services.AddApplicationTranslations();
            services.AddDispositions();
            services.AddEntities();

            services.AddScoped<IPermissionProvider, PermissionProvider>();
            services.AddScoped<IApplicationTableProvider, ApplicationTableProvider>();
            services.AddScoped<IOrganisationTypeTableProvider, OrganisationTypeTableProvider>();

            return services;
        }
    }
}