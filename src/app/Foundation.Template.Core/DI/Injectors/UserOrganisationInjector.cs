using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Foundation.Template.Core.Handlers;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.DI
{
    public static class UserOrganisationInjector
    {
        public static IServiceCollection AddUserOrganisations(this IServiceCollection services)
        {
            services.AddUserOrganisationTables();
            services.AddUserOrganisationColumns();

            return services;
        }

        private static IServiceCollection AddUserOrganisationTables(this IServiceCollection services)
        {
            services.AddScoped<UserOrganisationTablesQueryHandler>();
            services.AddScoped<IQueryHandler<UserOrganisationTablesQuery, IEnumerable<UserOrganisationTable>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UserOrganisationTablesQuery, IEnumerable<UserOrganisationTable>>()
                    // .With<PermissionsMiddleware>()
                    .Add<UserOrganisationTablesQueryHandler>()
                    .Build();

                return pipeline;
            });

            services.AddScoped<UserOrganisationTableQueryHandler>();
            services.AddScoped<IQueryHandler<UserOrganisationTableQuery, UserOrganisationTable>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UserOrganisationTableQuery, UserOrganisationTable>()
                    // .With<PermissionsMiddleware>()
                    .Add<UserOrganisationTableQueryHandler>()
                    .Build();

                return pipeline;
            });

            services.AddScoped<UpdateUserOrganisationTableCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserOrganisationTableCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateUserOrganisationTableCommand>()
                    // .With<PermissionsMiddleware>()
                    .Add<UpdateUserOrganisationTableCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }

        private static IServiceCollection AddUserOrganisationColumns(this IServiceCollection services)
        {
            services.AddScoped<UserOrganisationColumnsQueryHandler>();
            services.AddScoped<IQueryHandler<UserOrganisationColumnsQuery, IEnumerable<UserOrganisationColumn>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UserOrganisationColumnsQuery, IEnumerable<UserOrganisationColumn>>()
                    // .With<PermissionsMiddleware>()
                    .Add<UserOrganisationColumnsQueryHandler>()
                    .Build();

                return pipeline;
            });

            services.AddScoped<UpdateUserOrganisationColumnCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserOrganisationColumnCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateUserOrganisationColumnCommand>()
                    // .With<PermissionsMiddleware>()
                    .Add<UpdateUserOrganisationColumnCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}