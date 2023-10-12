using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Admin.DI
{
    public static class RoleAdminInjector
    {
        public static IServiceCollection AddRoleAdmin(this IServiceCollection services)
        {
            services.AddScoped<RoleAdminQueryHandler>();
            services.AddScoped<IQueryHandler<RoleAdminQuery, RoleAdminDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<RoleAdminQuery, RoleAdminDetails>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<RoleAdminQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpdateRoleAdminCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleAdminCommand, IEntity<Guid>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateRoleAdminCommand, IEntity<Guid>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<UpdateRoleAdminCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}