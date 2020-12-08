using Microsoft.EntityFrameworkCore.Migrations;

namespace TripCalculatorServer.Data.Migrations
{
    public partial class FullRelationOnTripElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "IdentityNumber");

            migrationBuilder.CreateTable(
                name: "DayOfWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripBags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripBags_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    DayOfWorkId = table.Column<int>(type: "int", nullable: false),
                    TripBagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripElement_DayOfWorks_DayOfWorkId",
                        column: x => x.DayOfWorkId,
                        principalTable: "DayOfWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripElement_TripBags_TripBagId",
                        column: x => x.TripBagId,
                        principalTable: "TripBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripBags_TripId",
                table: "TripBags",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripElement_DayOfWorkId",
                table: "TripElement",
                column: "DayOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_TripElement_TripBagId",
                table: "TripElement",
                column: "TripBagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripElement");

            migrationBuilder.DropTable(
                name: "DayOfWorks");

            migrationBuilder.DropTable(
                name: "TripBags");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.RenameColumn(
                name: "IdentityNumber",
                table: "Users",
                newName: "UserName");
        }
    }
}
