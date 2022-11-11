using EmployeeAPI.Interfaces;
using EmployeeAPI.Interfaces.IServices;
using EmployeeAPI.Interfaces.IUtilities;
using EmployeeAPI.Repository;
using EmployeeAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.IOC
{
    public static class IocContainer
    {
        public static void ConfigureIOC(this IServiceCollection services, IConfiguration configuration)
        {
            // addscope - created once per request
            // configure settings
            services.AddScoped<IConfigurationSettings, ConfigurationSettings>();

            // repo
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            // services
            services.AddScoped<IEmployeeService, EmployeeService>();

            // logger
            // transient - created each time they are requested
            services.AddTransient(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}
