using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Bones.Flow;

using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.Tools;
using Foundation.Template.Core.Providers;

namespace Foundation.Template.Core.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCoreTemplate(this IServiceCollection services, IConfiguration configuration)
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
            services.AddRolePermissionOrganisations();
            services.AddDispositions();
            services.AddUserOrganisations();

            services.AddScoped<IPermissionProvider, PermissionProvider>();
            services.AddScoped<IApplicationTableProvider, ApplicationTableProvider>();
            services.AddScoped<IOrganisationTypeTableProvider, OrganisationTypeTableProvider>();

            return services;
        }
    }
}