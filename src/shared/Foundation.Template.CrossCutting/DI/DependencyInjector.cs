using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Foundation.Clients.DI;

using Foundation.Template.Domain.Abstractions;
using Foundation.Template.CrossCutting.Services;

namespace Foundation.Template.CrossCutting.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFoundationClients(configuration);

            services.AddScoped<IClaimsFactory, ClaimsFactory>();
            services.AddScoped<IFoundationClientFactory, FoundationClientFactory>();
            services.AddScoped<ITranslationsProvider, TranslationsProvider>();
            services.AddScoped<ITemplateMatcher, RouteTemplateMatcher>();

            return services;
        }
    }
}