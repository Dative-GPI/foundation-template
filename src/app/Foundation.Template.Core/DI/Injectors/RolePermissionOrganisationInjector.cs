using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Core.Handlers;

namespace Foundation.Template.Core.DI
{
    public static class RolePermissionOrganisationInjector
    {
        public static IServiceCollection AddRolePermissionOrganisations(this IServiceCollection services)
        {
            services.AddScoped<RolePermissionOrganisationQueryHandler>();
            services.AddScoped<IQueryHandler<RolePermissionOrganisationQuery, RolePermissionOrganisationDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RolePermissionOrganisationQuery, RolePermissionOrganisationDetails>()
                    .With<PermissionsMiddleware>()
                    .Add<RolePermissionOrganisationQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRolePermissionOrganisationCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRolePermissionOrganisationCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRolePermissionOrganisationCommand, IEntity<Guid>>()
                    .With<PermissionsMiddleware>()
                    .Add<UpdateRolePermissionOrganisationCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}