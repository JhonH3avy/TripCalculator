using Microsoft.EntityFrameworkCore.Migrations;

namespace TripCalculatorServer.Data.Migrations
{
    public partial class TripBagHasWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BagWeight",
                table: "TripBags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BagWeight",
                table: "TripBags");
        }
    }
}
