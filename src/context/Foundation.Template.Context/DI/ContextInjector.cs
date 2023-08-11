using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Bones.Flow;

using Foundation.Template.Context.Configurations;
using Foundation.Template.Context.Abstractions;
using Foundation.Template.Context.Services;

namespace Foundation.Template.Context.DI
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : ApplicationContext
        {
            services.Configure<FileConfiguration>(configuration.GetSection("Files"));

            services.AddRepositories();

            services.AddDbContext<TContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PGSQL"));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<ApplicationContext, TContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IBinaryStorage, BinaryStorage>();

            return services;
        }
    }
}