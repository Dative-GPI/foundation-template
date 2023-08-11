using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Gateway.Handlers;

namespace Foundation.Template.Gateway.DI
{
    public static class ApplicationTranslationInjector
    {
        public static IServiceCollection AddApplicationTranslations(this IServiceCollection services)
        {
            services.AddScoped<ApplicationTranslationsQueryHandler>();
            services.AddScoped<IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>>(sp =>
            {
                var pipeline = sp.GetPipelineFactory<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>()
                    .Add<ApplicationTranslationsQueryHandler>()
                    .Build();
            
                return pipeline;
            });

            return services;
        }
    } 
}