using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Migrations
{
    public partial class endpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute");

            migrationBuilder.AlterColumn<int>(
                name: "EndPointId",
                table: "Commute",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute",
                column: "EndPointId",
                principalTable: "EndPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute");

            migrationBuilder.AlterColumn<int>(
                name: "EndPointId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute",
                column: "EndPointId",
                principalTable: "EndPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
