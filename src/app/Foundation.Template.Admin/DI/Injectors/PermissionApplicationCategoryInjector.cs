using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionApplicationCategoryInjector
    {
        public static IServiceCollection AddPermissionApplicationCategories(this IServiceCollection services)
        {
            services.AddScoped<PermissionApplicationCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionApplicationCategoriesQuery, IEnumerable<PermissionApplicationCategory>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionApplicationCategoriesQuery, IEnumerable<PermissionApplicationCategory>>()
                    .With<PermissionApplicationsMiddleware>()
                    .Add<PermissionApplicationCategoriesQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}