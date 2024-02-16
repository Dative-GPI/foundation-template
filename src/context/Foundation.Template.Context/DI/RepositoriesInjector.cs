using Microsoft.Extensions.DependencyInjection;


using Foundation.Template.Context.Repositories;
using Foundation.Template.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

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

            services.AddScoped<IPermissionApplicationRepository, PermissionApplicationRepository>();
            services.AddScoped<IPermissionApplicationCategoryRepository, PermissionApplicationCategoryRepository>();

            services.AddScoped<IRolePermissionOrganisationRepository, RolePermissionOrganisationRepository>();
            services.AddScoped<IRoleApplicationRepository, RoleApplicationRepository>();

            services.AddScoped<IApplicationTranslationRepository, ApplicationTranslationRepository>();
            services.AddScoped<ITranslationRepository, TranslationRepository>();

            services.AddScoped<IColumnRepository, ColumnRepository>();
            services.AddScoped<IEntityPropertyRepository, EntityPropertyRepository>();
            services.AddScoped<IOrganisationTypeDispositionRepository, OrganisationTypeDispositionRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
                        
            return services;
        }
    }
}