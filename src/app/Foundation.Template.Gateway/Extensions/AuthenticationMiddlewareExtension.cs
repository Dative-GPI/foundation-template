using Microsoft.AspNetCore.Builder;

using Foundation.Template.Gateway.Middlewares;

public static class AuthenticationMiddlewareExtension
{
    public static IApplicationBuilder UseJWTAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JWTAuthenticationMiddleware>();
    }
}
