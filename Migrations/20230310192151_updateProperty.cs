using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maskan.Migrations
{
    public partial class updateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Level",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Type",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Properties");
        }
    }
}
