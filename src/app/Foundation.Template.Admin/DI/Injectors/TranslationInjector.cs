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
    public static class TranslationInjector
    {
        public static IServiceCollection AddTranslations(this IServiceCollection services)
        {
            services.AddScoped<TranslationsQueryHandler>();

            services.AddScoped<IQueryHandler<TranslationsQuery, IEnumerable<Translation>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<TranslationsQuery, IEnumerable<Translation>>()
                    .With<PermissionsMiddleware>()
					.Add<TranslationsQueryHandler>()
                    .Build();

                return pipeline;
            });

            return services;
        }
    }
}