using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maskan.Migrations
{
    public partial class sellerfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuyerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalID = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "DealTypes",
                columns: table => new
                {
                    DealTypeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealTypes", x => x.DealTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SellerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalID = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    DealID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    SellerID = table.Column<long>(type: "bigint", nullable: false),
                    BuyerID = table.Column<long>(type: "bigint", nullable: false),
                    DealTypeID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.DealID);
                    table.ForeignKey(
                        name: "FK_Deals_Buyers_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyers",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_DealTypes_DealTypeID",
                        column: x => x.DealTypeID,
                        principalTable: "DealTypes",
                        principalColumn: "DealTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoogleMapsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    BedsNum = table.Column<long>(type: "bigint", nullable: false),
                    RoomsNum = table.Column<long>(type: "bigint", nullable: false),
                    BathsNum = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    VrLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealTypeID = table.Column<long>(type: "bigint", nullable: false),
                    SellerID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Properties_DealTypes_DealTypeID",
                        column: x => x.DealTypeID,
                        principalTable: "DealTypes",
                        principalColumn: "DealTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    CategoryGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: true),
                    CategoryID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.CategoryGroupID);
                    table.ForeignKey(
                        name: "FK_CategoryGroups_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_CategoryGroups_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesID);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_CategoryID",
                table: "CategoryGroups",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_PropertyID",
                table: "CategoryGroups",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_BuyerID",
                table: "Deals",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_DealTypeID",
                table: "Deals",
                column: "DealTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_SellerID",
                table: "Deals",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyID",
                table: "Images",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DealTypeID",
                table: "Properties",
                column: "DealTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SellerID",
                table: "Properties",
                column: "SellerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "DealTypes");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
