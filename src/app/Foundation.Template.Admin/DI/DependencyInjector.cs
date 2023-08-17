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
            services.AddCrossCutting(configuration);

            services.AddScoped<RequestContextProvider>();
            services.AddScoped<IRequestContextProvider>(sp 
                => sp.GetRequiredService<RequestContextProvider>());

            services.AddFlow();
            services.AddServices();
            services.AddMiddlewares();
            services.AddAutoMapper();

            services.AddPermissions();
            services.AddPermissionCategories();
            services.AddOrganisationTypePermissions();
            services.AddRoleOrganisation();

            services.AddPermissionAdmins();
            services.AddPermissionAdminCategories();
            services.AddRoleAdmin();

            services.AddTranslations();
            services.AddApplicationTranslations();

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