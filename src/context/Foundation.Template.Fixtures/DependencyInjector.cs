using Foundation.Template.Fixtures.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Template.Fixtures
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddFixtures(this IServiceCollection services)
        {
            services.AddScoped<IFixtureHelper, FixtureHelper>();

            return services;
        }
    }
}