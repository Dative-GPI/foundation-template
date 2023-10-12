using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class OrganisationTypePermissionOrganisationInjector
    {
        public static IServiceCollection AddOrganisationTypePermissionOrganisations(this IServiceCollection services)
        {
            services.AddScoped<OrganisationTypePermissionOrganisationsQueryHandler>();
            services.AddScoped<IQueryHandler<OrganisationTypePermissionOrganisationsQuery, IEnumerable<OrganisationTypePermissionOrganisationInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<OrganisationTypePermissionOrganisationsQuery, IEnumerable<OrganisationTypePermissionOrganisationInfos>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<OrganisationTypePermissionOrganisationsQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpsertOrganisationTypePermissionOrganistionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpsertOrganisationTypePermissionOrganisationsCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpsertOrganisationTypePermissionOrganisationsCommand>()
                    .Add<PermissionAdminsMiddleware>()
                    .Add<UpsertOrganisationTypePermissionOrganistionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}