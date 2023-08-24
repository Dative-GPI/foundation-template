using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Bones.Flow;

using Foundation.Template.CrossCutting.DI;

using Foundation.Template.Gateway.Abstractions;
using Foundation.Template.Gateway.Providers;
using Foundation.Template.Gateway.Services;
using Foundation.Template.Gateway.Middlewares;

namespace Foundation.Template.Gateway.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddGatewayTemplate(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddReverseProxy();
            services.AddHttpForwarder();
            services.AddMemoryCache();

            services.AddAuthentication(JWTAuthenticationMiddleware.AuthenticationScheme);

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);
            
            services.AddCrossCutting(configuration);
            services.AddSingleton<FoundationForwarderMiddleware>();

            services.AddScoped<RequestContextProvider>();
            services.AddScoped<IRequestContextProvider>(sp 
                => sp.GetRequiredService<RequestContextProvider>());

            services.AddFlow();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IApplicationTranslationService, ApplicationTranslationService>();

            services.AddImages();
            services.AddApplications();
            services.AddApplicationTranslations();

            return services;
        }
    }
}