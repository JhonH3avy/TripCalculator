using Microsoft.EntityFrameworkCore.Migrations;

namespace TripCalculatorServer.Data.Migrations
{
    public partial class DowNeedsAUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserIdentityNumber",
                table: "DayOfWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdentityNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWorks_UserIdentityNumber",
                table: "DayOfWorks",
                column: "UserIdentityNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfWorks_Users_UserIdentityNumber",
                table: "DayOfWorks",
                column: "UserIdentityNumber",
                principalTable: "Users",
                principalColumn: "IdentityNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfWorks_Users_UserIdentityNumber",
                table: "DayOfWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_DayOfWorks_UserIdentityNumber",
                table: "DayOfWorks");

            migrationBuilder.DropColumn(
                name: "UserIdentityNumber",
                table: "DayOfWorks");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
