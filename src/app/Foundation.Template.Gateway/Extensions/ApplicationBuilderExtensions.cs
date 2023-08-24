using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Foundation.Template.Gateway.Middlewares;
using Microsoft.AspNetCore.Routing;

namespace Foundation.Template.Gateway.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTemplateAuthentication(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JWTAuthenticationMiddleware>();
            builder.UseMiddleware<ClaimsToHeadersMiddleware>();
            builder.UseMiddleware<RequestContextInitializerMiddleware>();

            return builder;
        }

        public static IEndpointRouteBuilder MapGatewayTemplateEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var foundationForwarder = endpoints.ServiceProvider.GetRequiredService<FoundationForwarderMiddleware>();

            endpoints.MapControllers();
            endpoints.Map("/api/foundation/{**catch-all}", foundationForwarder.Forward)
                .AllowAnonymous();

            return endpoints;
        }
    }
}