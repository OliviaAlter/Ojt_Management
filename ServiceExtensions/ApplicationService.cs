using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OJTManagementAPI.DataContext;

namespace OJTManagementAPI.ServiceExtensions
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OjtManagementContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}