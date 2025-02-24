using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class mgSuppliers : Migration
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
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_supplierGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_supplierGroups", x => x.GroupId);
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

            migrationBuilder.CreateTable(
                name: "tbl_suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SupplierGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_tbl_suppliers_tbl_supplierGroups_SupplierGroupId",
                        column: x => x.SupplierGroupId,
                        principalTable: "tbl_supplierGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_suppliers_tbl_users_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskOwnerId = table.Column<int>(type: "int", nullable: false),
                    TaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskCreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_tbl_tasks_tbl_users_TaskCreatorId",
                        column: x => x.TaskCreatorId,
                        principalTable: "tbl_users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_tbl_suppliers_SupplierGroupId",
                table: "tbl_suppliers",
                column: "SupplierGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_suppliers_UserId",
                table: "tbl_suppliers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_tasks_TaskCreatorId",
                table: "tbl_tasks",
                column: "TaskCreatorId");

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
                name: "tbl_tasks");

            migrationBuilder.DropTable(
                name: "tbl_stocks");

            migrationBuilder.DropTable(
                name: "tbl_supplierGroups");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_orders");

            migrationBuilder.DropTable(
                name: "tbl_orderItems");
        }
    }
}
