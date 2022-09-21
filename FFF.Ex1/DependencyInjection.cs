using FFF.Ex1.DAL;
using FFF.Ex1.DAL.Models;
using FFF.Ex1.Logging;
using FFF.Ex1.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FFF.Ex1
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Регистрация сервисов в DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServiceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DataConnection"), opt =>
            {
                opt.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), null);
            })
            .UseSnakeCaseNamingConvention());
            services.AddTransient<IDataService, DataService>();

            services.AddTransient<IDbAuditLogger, DbAuditLogger>();
            services.AddTransient<IApplicationService, ApplicationService>();

            return services;
        }
    }
}
