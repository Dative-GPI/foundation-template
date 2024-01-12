using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Bones.Flow;

namespace XXXXX.Gateway.Kernel.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddKernel(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlow();

            services.AddAutoMapper(typeof(DependencyInjector).Assembly);

            return services;
        }
    }
}