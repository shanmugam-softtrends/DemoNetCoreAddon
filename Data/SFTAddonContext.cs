using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFTAddonDemo.Models;

namespace SFTAddonDemo.Data
{
    public class SFTAddonContext : DbContext
    {
        public SFTAddonContext(DbContextOptions<SFTAddonContext> options) : base(options)
        {
        }

        public SFTAddonContext() { }

        public DbSet<Resources> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Resources>().Property<DateTime>("updated_at");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resources>();
        }
    }
}
