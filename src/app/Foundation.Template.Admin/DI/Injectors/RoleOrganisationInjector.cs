using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Admin.DI
{
    public static class RoleOrganisationInjector
    {
        public static IServiceCollection AddRoleOrganisation(this IServiceCollection services)
        {
            services.AddScoped<RoleOrganisationQueryHandler>();
            services.AddScoped<IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RoleOrganisationQuery, RoleOrganisationDetails>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<RoleOrganisationQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRoleOrganisationCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRoleOrganisationCommand, IEntity<Guid>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<UpdateRoleOrganisationCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}