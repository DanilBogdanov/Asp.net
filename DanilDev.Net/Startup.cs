using DanilDev.Data;
using DanilDev.Services.CostControl;
using DanilDev.Services.EmploeesDirectory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string envName = CurrentEnvironment.EnvironmentName;
            string appConnectionString = Configuration.GetConnectionString("DefaultConnection");
            string projectDbContext;

            if (CurrentEnvironment.IsDevelopment())
            {
                projectDbContext = Configuration.GetConnectionString("AppConnectionStringDevelop");
            } else
            {
                projectDbContext = Configuration.GetConnectionString("AppConnectionString");
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(appConnectionString));
            
            services.AddDbContext<ProjectsDbContext>(options =>
                options.UseSqlServer(projectDbContext));            

            services.AddDefaultIdentity<ApplicationUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<CostControlService>();
            services.AddTransient<EmployeeDirectoryService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/{0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
