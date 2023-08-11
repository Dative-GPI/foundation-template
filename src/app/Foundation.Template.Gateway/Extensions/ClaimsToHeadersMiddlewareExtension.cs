using Microsoft.AspNetCore.Builder;

using Foundation.Template.Gateway.Middlewares;

public static class ClaimsToHeadersMiddlewareExtension
{
    public static IApplicationBuilder UseClaimsToHeadersMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClaimsToHeadersMiddleware>();
    }
}
