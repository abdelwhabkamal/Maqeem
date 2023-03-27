using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maskan.Migrations
{
    public partial class VrLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Furnished",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Region",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "VrLink",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Furnished",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "VrLink",
                table: "Properties");
        }
    }
}
