using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class mgUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_orderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_orderItems", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderItemsOrderItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_tbl_orders_tbl_orderItems_OrderItemsOrderItemId",
                        column: x => x.OrderItemsOrderItemId,
                        principalTable: "tbl_orderItems",
                        principalColumn: "OrderItemId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderItemsOrderItemId = table.Column<int>(type: "int", nullable: true),
                    StocksStockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_tbl_products_tbl_orderItems_OrderItemsOrderItemId",
                        column: x => x.OrderItemsOrderItemId,
                        principalTable: "tbl_orderItems",
                        principalColumn: "OrderItemId");
                    table.ForeignKey(
                        name: "FK_tbl_products_tbl_stocks_StocksStockId",
                        column: x => x.StocksStockId,
                        principalTable: "tbl_stocks",
                        principalColumn: "StockId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AdminApprove = table.Column<bool>(type: "bit", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tbl_users_tbl_orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "tbl_orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_OrderItemsOrderItemId",
                table: "tbl_orders",
                column: "OrderItemsOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_OrderItemsOrderItemId",
                table: "tbl_products",
                column: "OrderItemsOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_StocksStockId",
                table: "tbl_products",
                column: "StocksStockId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_OrdersOrderId",
                table: "tbl_users",
                column: "OrdersOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_products");

            migrationBuilder.DropTable(
                name: "tbl_suppliers");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_stocks");

            migrationBuilder.DropTable(
                name: "tbl_orders");

            migrationBuilder.DropTable(
                name: "tbl_orderItems");
        }
    }
}
