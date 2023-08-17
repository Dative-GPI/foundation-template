using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Foundation.Template.Gateway.Middlewares;

namespace Foundation.Template.Gateway.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGatewayTemplate(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JWTAuthenticationMiddleware>();
            builder.UseMiddleware<ClaimsToHeadersMiddleware>();
            builder.UseMiddleware<RequestContextInitializerMiddleware>();

            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                var foundationForwarder = endpoints.ServiceProvider.GetRequiredService<FoundationForwarderMiddleware>();

                endpoints.Map("/api/core/{**catch-all}", foundationForwarder.Forward)
                    .AllowAnonymous();
            });

            return builder;
        }
    }
}