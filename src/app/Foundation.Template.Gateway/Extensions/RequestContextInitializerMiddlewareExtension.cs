using Microsoft.AspNetCore.Builder;

using Foundation.Template.Gateway.Middlewares;

public static class RequestContextInitializerMiddlewareExtension
{
    public static IApplicationBuilder UseCustomContext(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestContextInitializerMiddleware>();
    }
}