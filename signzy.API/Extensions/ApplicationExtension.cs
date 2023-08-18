using signzy.API.Attribute;
using signzy.Application.Interfaces;
using signzy.Application.Services;
using signzy.Infrastucture.Interfaces;
using signzy.Infrastucture.Repositories;

namespace signzy.API.Extensions
{
    public static class ApplicationExtension
    {
        /// <summary>
        /// ConfigureCustomMiddleware
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomMiddleware(this IApplicationBuilder app)
        {
            //app.UseMiddleware<ExceptionMiddleware>();
        }

        /// <summary>
        /// ConfigureAuditing
        /// </summary>
        /// <param name="app"></param>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureAuditing(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });

            return app;
        }

        /// <summary>
        /// ConfigureSettings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        /// <summary>
        /// ConfigureDependency
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDependency(this IServiceCollection services)
        {
            services.AddScoped<Authentication>();
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginservice, LoginService>();

            return services;
        }
    }
}
