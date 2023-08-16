using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Shell.Handlers;

namespace Foundation.Template.Shell.DI
{
    public static class RoleOrganisationInjector
    {
        public static IServiceCollection AddRoleOrganisations(this IServiceCollection services)
        {
            services.AddScoped<RoleOrganisationQueryHandler>();
            services.AddScoped<IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RoleOrganisationQuery, RoleOrganisationDetails>()
                    .With<PermissionsMiddleware>()
                    .Add<RoleOrganisationQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRolePermissionsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRolePermissionsCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRolePermissionsCommand, IEntity<Guid>>()
                    .With<PermissionsMiddleware>()
                    .Add<UpdateRolePermissionsCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}