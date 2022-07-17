using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Options;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.Repositories;
using OJTManagementAPI.ServiceInterfaces;
using OJTManagementAPI.Services;

namespace OJTManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OJTManagementAPI", Version = "v1" });
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();

            services.AddScoped<ISemesterCompanyService, SemesterCompanyService>();
            services.AddScoped<ISemesterCompanyRepository, SemesterCompanyRepository>();

            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IMajorRepository, MajorRepository>();

            services.AddDbContext<OjtManagementContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OJTManagementAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name : "areas",
                    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            */
            app.UseHttpsRedirection();
        }
    }
}