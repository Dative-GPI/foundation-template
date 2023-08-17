using Microsoft.AspNetCore.Builder;

using Foundation.Template.Admin.Middlewares;

namespace Foundation.Template.Admin.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAdminTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestContextInitializerMiddleware>();
        }
    }
}