using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SFTAddonDemo.Helpers;
using SFTAddonDemo.Data;
using Microsoft.EntityFrameworkCore;
using SFTAddonDemo.Repositories;
using SFTAddonDemo.Extensions;

namespace SFTAddonDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                //Environment.SetEnvironmentVariable("HEROKU_USERNAME", "shan");
                //Environment.SetEnvironmentVariable("HEROKU_PASSWORD", "123");
                Environment.SetEnvironmentVariable("DATABASE_URL", "postgres://fpllonwhzpwnlg:vNTNxd1oqFX4HQLgB4tZ4WcSC7@ec2-23-21-235-126.compute-1.amazonaws.com:5432/da4a0spnf5r40p");
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();

            ConnectionString = Utilities.GetPGConnectionString(Utilities.GetEnvVarVal("DATABASE_URL"));
            Globals.EnsureDatabaseCreated(ConnectionString, env);
        }

        public IConfigurationRoot Configuration { get; }
        public string ConnectionString { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //db setting
            services.AddEntityFrameworkNpgsql().AddDbContext<SFTAddonContext>(options => options.UseNpgsql(ConnectionString, b => b.MigrationsAssembly("SFTAddonDemo")));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddScoped<IResourcesRepository, ResourcesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMiddleware<HerokuAuthorizationMiddleware>();

            app.UseHerokuAuthorizationMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //try
            //{
            //    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //    {
            //        serviceScope.ServiceProvider.GetService<SFTAddonContext>().Database.Migrate();
            //    }
            //}
            //catch (Exception e)
            //{
            //    var msg = e.Message;
            //    var stacktrace = e.StackTrace;
            //}
        }
    }
}
