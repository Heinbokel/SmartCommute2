using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Data.Migrations
{
    public partial class _33333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId1",
                table: "Commute");

            migrationBuilder.DropIndex(
                name: "IX_Commute_UserId1",
                table: "Commute");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Commute");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Commute_UserId",
                table: "Commute",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute");

            migrationBuilder.DropIndex(
                name: "IX_Commute_UserId",
                table: "Commute");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Commute",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commute_UserId1",
                table: "Commute",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_AspNetUsers_UserId1",
                table: "Commute",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
