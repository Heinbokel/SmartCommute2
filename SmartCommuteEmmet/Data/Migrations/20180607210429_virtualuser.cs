using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Data.Migrations
{
    public partial class virtualuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_AspNetUsers_UserId",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute");

            migrationBuilder.DropIndex(
                name: "IX_Business_UserId",
                table: "Business");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commute",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Business",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Business",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Business_UserId",
                table: "Business",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_AspNetUsers_UserId",
                table: "Business",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
