using Microsoft.EntityFrameworkCore.Migrations;

namespace TripCalculatorServer.Data.Migrations
{
    public partial class AdjustModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DayOfWorks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWorks_UserId",
                table: "DayOfWorks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfWorks_Users_UserId",
                table: "DayOfWorks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfWorks_Users_UserId",
                table: "DayOfWorks");

            migrationBuilder.DropIndex(
                name: "IX_DayOfWorks_UserId",
                table: "DayOfWorks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DayOfWorks");
        }
    }
}
