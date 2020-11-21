using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using AspNetCore.RouteAnalyzer;

namespace SjonnieLoper
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
            /*var factory =
                new RedisConnectionFactory(("Docker",
                    Configuration.GetConnectionString("DockerRedisServerUrl")));*/
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Configuration
                .GetConnectionString("DockerRedisServerUrl")); 
            services.AddSingleton<IConnectionMultiplexer>(redis);
            
            /*services.RegisterRedisServices(Configuration
                .GetConnectionString("DockerRedisServerUrl"));*/

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DockerSqlConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => 
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
                options.AddPolicy("EmployeeOnly", policy =>
                    policy.RequireClaim("Role")));

            services.AddRazorPages().AddMvcOptions(o =>
            {
                o.Filters.Add(new AuthorizeFilter());
            });
            services.RegisterWhiskeyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }

    }
}