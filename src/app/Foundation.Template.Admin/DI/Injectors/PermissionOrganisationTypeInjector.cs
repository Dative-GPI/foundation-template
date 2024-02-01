using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;

namespace Foundation.Template.Admin.DI
{
    public static class PermissionOrganisationTypeInjector
    {
        public static IServiceCollection AddPermissionOrganisationTypes(this IServiceCollection services)
        {
            services.AddScoped<PermissionOrganisationTypesQueryHandler>();
            services.AddScoped<IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionOrganisationTypeInfos>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<PermissionOrganisationTypesQuery, IEnumerable<PermissionOrganisationTypeInfos>>()
                    .With<PermissionAdminsMiddleware>()
                    .Add<PermissionOrganisationTypesQueryHandler>()
                    .Build();

                return pipeline;
            });


            services.AddScoped<UpsertPermissionOrganisationTypesCommandHandler>();
            services.AddScoped<ICommandHandler<UpsertPermissionOrganisationTypesCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpsertPermissionOrganisationTypesCommand>()
                    .Add<PermissionAdminsMiddleware>()
                    .Add<UpsertPermissionOrganisationTypesCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}