using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maskan.Migrations
{
    public partial class addAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Countries_CountryID",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CountryID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Properties");

            migrationBuilder.AddColumn<long>(
                name: "CountryID",
                table: "Properties",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CountryID",
                table: "Properties",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Countries_CountryID",
                table: "Properties",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");
        }
    }
}
