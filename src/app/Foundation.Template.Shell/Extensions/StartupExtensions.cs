using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Template.Shell.Extensions
{
    public static class StartupExtensions
    {
        public static IEndpointRouteBuilder MapShellTemplateControllers(this IEndpointRouteBuilder endpoints, string subPath)
        {
            endpoints.MapControllers();

            return endpoints;
        }
    }
}
