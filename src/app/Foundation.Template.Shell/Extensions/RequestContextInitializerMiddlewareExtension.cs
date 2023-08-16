using Microsoft.AspNetCore.Builder;

using Foundation.Template.Shell.Middlewares;

public static class RequestContextInitializerMiddlewareExtension
{
    public static IApplicationBuilder UseShellTemplate(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestContextInitializerMiddleware>();
    }
}