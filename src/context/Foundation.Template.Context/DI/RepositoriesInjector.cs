using Microsoft.Extensions.DependencyInjection;


using Foundation.Template.Context.Repositories;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Context.DI
{
    public static class RepositoriesInjector
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<IPermissionOrganisationRepository, PermissionOrganisationRepository>();
            services.AddScoped<IPermissionOrganisationCategoryRepository, PermissionOrganisationCategoryRepository>();
            services.AddScoped<IPermissionOrganisationTypeRepository, PermissionOrganisationTypeRepository>();

            services.AddScoped<IPermissionAdminRepository, PermissionAdminRepository>();
            services.AddScoped<IPermissionAdminCategoryRepository, PermissionAdminCategoryRepository>();

            services.AddScoped<IRoleOrganisationRepository, RoleOrganisationRepository>();
            services.AddScoped<IRoleAdminRepository, RoleAdminRepository>();

            services.AddScoped<IApplicationTranslationRepository, ApplicationTranslationRepository>();
            services.AddScoped<ITranslationRepository, TranslationRepository>();

            return services;
        }
    }
}