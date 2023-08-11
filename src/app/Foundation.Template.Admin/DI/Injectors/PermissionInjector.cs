using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionInjector
    {
        public static IServiceCollection AddPermissions(this IServiceCollection services)
        {
            services.AddScoped<PermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionsQuery, IEnumerable<PermissionInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<PermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}