using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;
using Foundation.Template.Core.Handlers;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.DI
{
    public static class UserOrganisationDispositionInjector
    {
        public static IServiceCollection AddUserOrganisationDispositions(this IServiceCollection services)
        {
            services.AddScoped<UserOrganisationDispositionsQueryHandler>();
            services.AddScoped<IQueryHandler<UserOrganisationDispositionsQuery, UserOrganisationDisposition>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UserOrganisationDispositionsQuery, UserOrganisationDisposition>()
                    // .With<PermissionsMiddleware>()
                    .Add<UserOrganisationDispositionsQueryHandler>()
                    .Build();

                return pipeline;
            });

            services.AddScoped<UpdateUserOrganisationDispositionCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserOrganisationDispositionCommand>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<UpdateUserOrganisationDispositionCommand>()
                    // .With<PermissionsMiddleware>()
                    .Add<UpdateUserOrganisationDispositionCommandHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}