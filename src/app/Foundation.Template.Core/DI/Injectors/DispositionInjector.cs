using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Foundation.Template.Core.Handlers;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.DI
{
    public static class DispositionInjector
    {
        public static IServiceCollection AddDispositions(this IServiceCollection services)
        {
            services.AddTables();
            services.AddColumns();
            services.AddOrganisationTypeDispositions();

            return services;
        }

        private static IServiceCollection AddTables(this IServiceCollection services)
        {

            services.AddScoped<TableQueryHandler>();
            services.AddScoped<IQueryHandler<TableQuery, ApplicationTableDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<TableQuery, ApplicationTableDetails>()
                    // .With<PermissionsMiddleware>()
                    .Add<TableQueryHandler>()
                    .Build();

                return pipeline;
            });


            return services;
        }

        private static IServiceCollection AddColumns(this IServiceCollection services)
        {

            services.AddScoped<ColumnsQueryHandler>();
            services.AddScoped<IQueryHandler<ColumnsQuery, IEnumerable<Column>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ColumnsQuery, IEnumerable<Column>>()
                    // .With<PermissionsMiddleware>()
                    .Add<ColumnsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }


        private static IServiceCollection AddOrganisationTypeDispositions(this IServiceCollection services)
        {

            services.AddScoped<OrganisationTypeTableQueryHandler>();
            services.AddScoped<IQueryHandler<OrganisationTypeTableQuery, OrganisationTypeTableDetails>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<OrganisationTypeTableQuery, OrganisationTypeTableDetails>()
                    // .With<PermissionsMiddleware>()
                    .Add<OrganisationTypeTableQueryHandler>()
                    .Build();

                return pipeline;
            });


            return services;
        }
    }
}