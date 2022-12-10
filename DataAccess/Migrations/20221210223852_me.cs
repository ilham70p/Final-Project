using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class me : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_CarModelId",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarModelId",
                table: "Features",
                column: "CarModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_CarModelId",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarModelId",
                table: "Features",
                column: "CarModelId");
        }
    }
}
