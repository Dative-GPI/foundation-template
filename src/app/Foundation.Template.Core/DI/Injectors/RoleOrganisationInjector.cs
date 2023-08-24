using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Core.Handlers;

namespace Foundation.Template.Core.DI
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


            services.AddScoped<UpdateRoleOrganisationCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRoleOrganisationCommand, IEntity<Guid>>()
                    .With<PermissionsMiddleware>()
                    .Add<UpdateRoleOrganisationCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}