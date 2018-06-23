using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Migrations
{
    public partial class june22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BreakfastCity = table.Column<string>(nullable: false),
                    BreakfastDescription = table.Column<string>(nullable: true),
                    BreakfastLink = table.Column<string>(nullable: true),
                    BreakfastName = table.Column<string>(nullable: false),
                    BreakfastStreet = table.Column<string>(nullable: false),
                    BreakfastZIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorDescription = table.Column<string>(maxLength: 50, nullable: true),
                    SponsorImagePath = table.Column<string>(nullable: true),
                    SponsorLink = table.Column<string>(nullable: false),
                    SponsorName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfast");

            migrationBuilder.DropTable(
                name: "Sponsor");
        }
    }
}
