using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Migrations
{
    public partial class commuterevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_StartPoint_StartPointId",
                table: "Commute");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StartPointId",
                table: "Commute",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_StartPoint_StartPointId",
                table: "Commute",
                column: "StartPointId",
                principalTable: "StartPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_StartPoint_StartPointId",
                table: "Commute");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_AspNetUsers_UserId",
                table: "Commute");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Commute",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "StartPointId",
                table: "Commute",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_StartPoint_StartPointId",
                table: "Commute",
                column: "StartPointId",
                principalTable: "StartPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
