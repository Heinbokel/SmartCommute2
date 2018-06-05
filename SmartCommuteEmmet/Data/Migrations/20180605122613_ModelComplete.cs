using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Data.Migrations
{
    public partial class ModelComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Business");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Point",
                newName: "PointLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Point",
                newName: "PointLatitude");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Point",
                newName: "PointDescription");

            migrationBuilder.RenameColumn(
                name: "CommuteName",
                table: "CommuteType",
                newName: "CommuteTypeName");

            migrationBuilder.RenameColumn(
                name: "CommuteDescription",
                table: "CommuteType",
                newName: "CommuteTypeDescription");

            migrationBuilder.RenameColumn(
                name: "BusinessTeamCaptain",
                table: "Business",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Business",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserStreet",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCity",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Business_UserId",
                table: "Business",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_AspNetUsers_UserId",
                table: "Business",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_AspNetUsers_UserId",
                table: "Business");

            migrationBuilder.DropIndex(
                name: "IX_Business_UserId",
                table: "Business");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PointLongitude",
                table: "Point",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "PointLatitude",
                table: "Point",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "PointDescription",
                table: "Point",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CommuteTypeName",
                table: "CommuteType",
                newName: "CommuteName");

            migrationBuilder.RenameColumn(
                name: "CommuteTypeDescription",
                table: "CommuteType",
                newName: "CommuteDescription");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Business",
                newName: "BusinessTeamCaptain");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessTeamCaptain",
                table: "Business",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Business",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserStreet",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCity",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId");
        }
    }
}
