using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

using Foundation.Template.Gateway.Abstractions;
using Foundation.Template.Gateway.Providers;
using Foundation.Template.Gateway.Services;

namespace Foundation.Template.Gateway.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddGatewayTemplate(this IServiceCollection services)
        {
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