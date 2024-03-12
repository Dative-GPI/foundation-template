using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Foundation.Template.Core.Handlers;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.DI
{
    public static class TableInjector
    {
        public static IServiceCollection AddTables(this IServiceCollection services)
        {
            services.AddScoped<TableQueryHandler>();
            services.AddScoped<IQueryHandler<TableQuery, UserTable>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<TableQuery, UserTable>()
                    // .With<PermissionsMiddleware>()
                    .Add<TableQueryHandler>()
                    .Build();

                return pipeline;
            });

            services.AddScoped<UpdateTableCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateTableCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateTableCommand>()
                    // .With<PermissionsMiddleware>()
                    .Add<UpdateTableCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}