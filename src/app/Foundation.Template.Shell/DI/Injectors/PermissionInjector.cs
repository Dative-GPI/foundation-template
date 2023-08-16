using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Shell.Handlers;

namespace Foundation.Template.Shell.DI
{
    public static class PermissionInjector
    {
        public static IServiceCollection AddPermissions(this IServiceCollection services)
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