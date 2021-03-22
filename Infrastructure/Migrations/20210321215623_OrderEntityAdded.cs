using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class OrderEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DeliveryMethods",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>("nvarchar(max)", nullable: true),
                    DeliveryTime = table.Column<string>("nvarchar(max)", nullable: true),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_DeliveryMethods", x => x.Id); });

            migrationBuilder.CreateTable(
                "Orders",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerEmail = table.Column<string>("nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTimeOffset>("datetimeoffset", nullable: false),
                    ShipToAddress_FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                    ShipToAddress_LastName = table.Column<string>("nvarchar(max)", nullable: true),
                    ShipToAddress_Street = table.Column<string>("nvarchar(max)", nullable: true),
                    ShipToAddress_City = table.Column<string>("nvarchar(max)", nullable: true),
                    ShipToAddress_State = table.Column<string>("nvarchar(max)", nullable: true),
                    ShipToAddress_ZipCode = table.Column<string>("nvarchar(max)", nullable: true),
                    DeliveryMethodId = table.Column<int>("int", nullable: true),
                    Subtotal = table.Column<decimal>("decimal(18,2)", nullable: false),
                    Status = table.Column<string>("nvarchar(max)", nullable: false),
                    PaymentItentId = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        x => x.DeliveryMethodId,
                        "DeliveryMethods",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "OrderItems",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOrder_ProductItemId = table.Column<int>("int", nullable: true),
                    ItemOrder_ProductName = table.Column<string>("nvarchar(max)", nullable: true),
                    ItemOrder_PictureUrl = table.Column<string>("nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>("int", nullable: false),
                    OrderId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderItems_Orders_OrderId",
                        x => x.OrderId,
                        "Orders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_OrderItems_OrderId",
                "OrderItems",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_Orders_DeliveryMethodId",
                "Orders",
                "DeliveryMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "OrderItems");

            migrationBuilder.DropTable(
                "Orders");

            migrationBuilder.DropTable(
                "DeliveryMethods");
        }
    }
}