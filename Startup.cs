using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OJTManagementAPI.Options;
using OJTManagementAPI.ServiceExtensions;
using Swashbuckle.AspNetCore.Filters;

namespace OJTManagementAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OJTManagementAPI", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("https://localhost:3000", "https://localhost:3001")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.Configure<PaginationOptions>(_configuration.GetSection("Pagination"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScopedService();

            services.AddIdentityServices(_configuration);

            services.AddApplicationService(_configuration);

            services.AddAuthorization(o =>
            {
                o.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
                o.AddPolicy("Company", policy => policy.RequireClaim("Company"));
            });

            services.AddMvc();
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(x =>
                x.AllowAnyHeader().AllowAnyMethod()
                    .WithOrigins("http://localhost:3000", "https://localhost:3001"));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        
            */

            app.UseHttpsRedirection();
        }
    }
}