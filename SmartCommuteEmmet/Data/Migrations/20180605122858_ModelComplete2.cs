using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartCommuteEmmet.Data.Migrations
{
    public partial class ModelComplete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_Point_PointId",
                table: "Commute");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "Commute",
                newName: "StartPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Commute_PointId",
                table: "Commute",
                newName: "IX_Commute_StartPointId");

            migrationBuilder.AddColumn<int>(
                name: "EndPointId",
                table: "Commute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EndPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointDescription = table.Column<string>(nullable: true),
                    EndPointLatitude = table.Column<float>(nullable: false),
                    EndPointLongitude = table.Column<float>(nullable: false),
                    EndPointName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartPointDescription = table.Column<string>(nullable: true),
                    StartPointLatitude = table.Column<float>(nullable: false),
                    StartPointLongitude = table.Column<float>(nullable: false),
                    StartPointName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartPoint", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commute_EndPointId",
                table: "Commute",
                column: "EndPointId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commute_EndPoint_EndPointId",
                table: "Commute");

            migrationBuilder.DropForeignKey(
                name: "FK_Commute_StartPoint_StartPointId",
                table: "Commute");

            migrationBuilder.DropTable(
                name: "EndPoint");

            migrationBuilder.DropTable(
                name: "StartPoint");

            migrationBuilder.DropIndex(
                name: "IX_Commute_EndPointId",
                table: "Commute");

            migrationBuilder.DropColumn(
                name: "EndPointId",
                table: "Commute");

            migrationBuilder.RenameColumn(
                name: "StartPointId",
                table: "Commute",
                newName: "PointId");

            migrationBuilder.RenameIndex(
                name: "IX_Commute_StartPointId",
                table: "Commute",
                newName: "IX_Commute_PointId");

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointDescription = table.Column<string>(nullable: true),
                    PointLatitude = table.Column<float>(nullable: false),
                    PointLongitude = table.Column<float>(nullable: false),
                    PointName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Commute_Point_PointId",
                table: "Commute",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
