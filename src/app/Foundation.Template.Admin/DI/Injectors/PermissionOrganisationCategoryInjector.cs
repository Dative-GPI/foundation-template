using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionOrganisationCategoryInjector
    {
        public static IServiceCollection AddPermissionOrganisationCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionOrganisationCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionOrganisationCategoriesQuery, IEnumerable<PermissionOrganisationCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionOrganisationCategoriesQuery, IEnumerable<PermissionOrganisationCategory>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<PermissionOrganisationCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}