using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class postdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_CarModels_CarModelId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_CarModelId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Features");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_FeatureId",
                table: "CarModels",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Features_FeatureId",
                table: "CarModels",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Features_FeatureId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_FeatureId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarModelId",
                table: "Features",
                column: "CarModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_CarModels_CarModelId",
                table: "Features",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
