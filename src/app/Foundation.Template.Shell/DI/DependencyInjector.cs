using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Shell.Tools;
using Bones.Flow;

namespace Foundation.Template.Shell.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddShellTemplate(this IServiceCollection services)
        {
            services.AddScoped<RequestContextProvider>();
            services.AddScoped<IRequestContextProvider>(sp 
                => sp.GetRequiredService<RequestContextProvider>());

            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();

            services.AddPermissions();
            services.AddRoleOrganisations();
            
            services.AddAutoMapper();

            services.AddScoped<IPermissionProvider, PermissionProvider>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}