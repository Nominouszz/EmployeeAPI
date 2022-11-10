using EmployeeAPI.Interfaces;
using EmployeeAPI.Interfaces.IServices;
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
            // repo
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            // services
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
