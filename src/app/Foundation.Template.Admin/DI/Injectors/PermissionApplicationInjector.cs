using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionApplicationInjector
    {
        public static IServiceCollection AddPermissionApplications(this IServiceCollection services)
        {
            services.AddScoped<PermissionApplicationsQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionApplicationsQuery, IEnumerable<PermissionApplicationInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionApplicationsQuery, IEnumerable<PermissionApplicationInfos>>()
                    .With<PermissionApplicationsMiddleware>()
                    .Add<PermissionApplicationsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}