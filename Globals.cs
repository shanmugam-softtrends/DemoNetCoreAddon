using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SFTAddonDemo.Data;

namespace SFTAddonDemo
{
    public static class Globals
    {
        public static void EnsureDatabaseCreated(string constr, IHostingEnvironment hostEnv)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SFTAddonContext>();
            //if (hostEnv.IsDevelopment()) optionsBuilder.UseNpgsql(Configuration["Data:dev:DataContext"]);
            //else if (hostEnv.IsStaging()) optionsBuilder.UseNpgsql(Configuration["Data:staging:DataContext"]);
            //else if (hostEnv.IsProduction())
            optionsBuilder.UseNpgsql(constr);
            using (var context = new SFTAddonContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
