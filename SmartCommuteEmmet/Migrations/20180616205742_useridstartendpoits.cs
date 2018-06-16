using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Migrations
{
    public partial class useridstartendpoits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StartPoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EndPoint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StartPoint");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EndPoint");
        }
    }
}
