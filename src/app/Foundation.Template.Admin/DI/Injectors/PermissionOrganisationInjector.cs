using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionOrganisationInjector
    {
        public static IServiceCollection AddPermissions(this IServiceCollection services)
        {
            services.AddScoped<PermissionOrganisationsQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionOrganisationsQuery, IEnumerable<PermissionOrganisationInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionOrganisationsQuery, IEnumerable<PermissionOrganisationInfos>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<PermissionOrganisationsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}