using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SFTAddonDemo.Data;

namespace SFTAddonDemo.Migrations
{
    [DbContext(typeof(SFTAddonContext))]
    [Migration("20161202060730_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SFTAddonDemo.Models.Resources", b =>
                {
                    b.Property<string>("uuid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("callback_url");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("heroku_id");

                    b.Property<string>("plan");

                    b.Property<string>("region");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("uuid");

                    b.ToTable("Resources");
                });
        }
    }
}
