using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionAdminCategoryInjector
    {
        public static IServiceCollection AddPermissionAdminCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionAdminCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<PermissionAdminCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}