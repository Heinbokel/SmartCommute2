using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Data.Migrations
{
    public partial class guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Commute",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Business",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Business",
                nullable: true,
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
