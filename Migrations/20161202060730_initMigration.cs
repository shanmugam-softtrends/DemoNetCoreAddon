using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFTAddonDemo.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "public",
                columns: table => new
                {
                    uuid = table.Column<string>(nullable: false),
                    callback_url = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    heroku_id = table.Column<string>(nullable: true),
                    plan = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.uuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources",
                schema: "public");
        }
    }
}
