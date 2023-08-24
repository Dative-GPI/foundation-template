using Microsoft.AspNetCore.Builder;

using Foundation.Template.Core.Middlewares;

public static class RequestContextInitializerMiddlewareExtension
{
    public static IApplicationBuilder UseCoreTemplate(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestContextInitializerMiddleware>();
    }
}