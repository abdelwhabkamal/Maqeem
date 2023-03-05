using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maskan.Migrations
{
    public partial class fkupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Admins_AdminID",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Admins_AdminID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_AdminID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_AdminID",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AdminID",
                table: "Sellers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AdminID",
                table: "Buyers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AdminID",
                table: "Sellers",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AdminID",
                table: "Buyers",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Admins_AdminID",
                table: "Buyers",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Admins_AdminID",
                table: "Sellers",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
