using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Handlers;
using Foundation.Template.Admin.Requests;

namespace Foundation.Template.Admin.DI
{
    public static class ApplicationTranslationInjector
    {
        public static IServiceCollection AddApplicationTranslations(this IServiceCollection services)
        {
            services.AddScoped<ApplicationTranslationsQueryHandler>();
            services.AddScoped<IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>()
                    .With<PermissionAdminsMiddleware>()
					.Add<ApplicationTranslationsQueryHandler>()
                    .Build();

                return pipeline;
            });

            
            services.AddScoped<UpdateApplicationTranslationsCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateApplicationTranslationCommand>>(sp => 
            {
                var pipeline = sp.GetPipelineFactory<UpdateApplicationTranslationCommand>()
                    .Add<PermissionAdminsMiddleware>()
                    .Add<UpdateApplicationTranslationsCommandHandler>()
                    .Build();
                
                return pipeline;
            });

            return services;
        }
    }
}