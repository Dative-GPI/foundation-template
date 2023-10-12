using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Template.Core.Extensions
{
    public static class StartupExtensions
    {
        public static IEndpointRouteBuilder MapCoreTemplateControllers(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();

            return endpoints;
        }
    }
}
