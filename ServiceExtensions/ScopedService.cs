using Microsoft.Extensions.DependencyInjection;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.Repositories;
using OJTManagementAPI.ServiceInterfaces;
using OJTManagementAPI.Services;

namespace OJTManagementAPI.ServiceExtensions
{
    public static class ScopedService
    {
        public static IServiceCollection AddScopedService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IMajorRepository, MajorRepository>();

            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();

            services.AddScoped<ISemesterCompanyService, SemesterCompanyService>();
            services.AddScoped<ISemesterCompanyRepository, SemesterCompanyRepository>();

            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ITokenServices, TokenServices>();

            return services;
        }
    }
}