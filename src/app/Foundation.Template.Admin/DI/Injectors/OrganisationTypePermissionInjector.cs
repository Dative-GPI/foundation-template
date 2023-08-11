using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class OrganisationTypePermissionInjector
    {
        public static IServiceCollection AddOrganisationTypePermissions(this IServiceCollection services)
        {
            services.AddScoped<OrganisationTypePermissionsQueryHandler>();
            services.AddScoped<IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<OrganisationTypePermissionInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<OrganisationTypePermissionsQuery, IEnumerable<OrganisationTypePermissionInfos>>()
                    .With<PermissionsMiddleware>()
                    .Add<OrganisationTypePermissionsQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpsertOrganisationTypePermissionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpsertOrganisationTypePermissionsCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpsertOrganisationTypePermissionsCommand>()
                    .Add<PermissionsMiddleware>()
                    .Add<UpsertOrganisationTypePermissionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}