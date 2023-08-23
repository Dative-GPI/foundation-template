using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Bones.Flow;

using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Shell.Tools;

namespace Foundation.Template.Shell.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddShellTemplate(this IServiceCollection services, IConfiguration configuration)
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
            services.AddRoleOrganisations();

            services.AddScoped<IPermissionProvider, PermissionProvider>();

            return services;
        }
    }
}