using Microsoft.EntityFrameworkCore.Migrations;

namespace TripCalculatorServer.Data.Migrations
{
    public partial class TripElemetNotRelatedToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripElement_DayOfWorks_DayOfWorkId",
                table: "TripElement");

            migrationBuilder.DropForeignKey(
                name: "FK_TripElement_TripBags_TripBagId",
                table: "TripElement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripElement",
                table: "TripElement");

            migrationBuilder.RenameTable(
                name: "TripElement",
                newName: "TripElements");

            migrationBuilder.RenameIndex(
                name: "IX_TripElement_TripBagId",
                table: "TripElements",
                newName: "IX_TripElements_TripBagId");

            migrationBuilder.RenameIndex(
                name: "IX_TripElement_DayOfWorkId",
                table: "TripElements",
                newName: "IX_TripElements_DayOfWorkId");

            migrationBuilder.AlterColumn<int>(
                name: "TripBagId",
                table: "TripElements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripElements",
                table: "TripElements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripElements_DayOfWorks_DayOfWorkId",
                table: "TripElements",
                column: "DayOfWorkId",
                principalTable: "DayOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripElements_TripBags_TripBagId",
                table: "TripElements",
                column: "TripBagId",
                principalTable: "TripBags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripElements_DayOfWorks_DayOfWorkId",
                table: "TripElements");

            migrationBuilder.DropForeignKey(
                name: "FK_TripElements_TripBags_TripBagId",
                table: "TripElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripElements",
                table: "TripElements");

            migrationBuilder.RenameTable(
                name: "TripElements",
                newName: "TripElement");

            migrationBuilder.RenameIndex(
                name: "IX_TripElements_TripBagId",
                table: "TripElement",
                newName: "IX_TripElement_TripBagId");

            migrationBuilder.RenameIndex(
                name: "IX_TripElements_DayOfWorkId",
                table: "TripElement",
                newName: "IX_TripElement_DayOfWorkId");

            migrationBuilder.AlterColumn<int>(
                name: "TripBagId",
                table: "TripElement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripElement",
                table: "TripElement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripElement_DayOfWorks_DayOfWorkId",
                table: "TripElement",
                column: "DayOfWorkId",
                principalTable: "DayOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripElement_TripBags_TripBagId",
                table: "TripElement",
                column: "TripBagId",
                principalTable: "TripBags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
