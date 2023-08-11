using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionCategoryInjector
    {
        public static IServiceCollection AddPermissionCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>()
                    .With<PermissionsMiddleware>()
                    .Add<PermissionCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}