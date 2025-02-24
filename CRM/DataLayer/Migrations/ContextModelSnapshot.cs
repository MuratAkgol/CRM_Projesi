﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.OrderItems", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"), 1L, 1);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.ToTable("tbl_orderItems");
                });

            modelBuilder.Entity("EntityLayer.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderItemsOrderItemId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderItemsOrderItemId");

                    b.ToTable("tbl_orders");
                });

            modelBuilder.Entity("EntityLayer.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderItemsOrderItemId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("StocksStockId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderItemsOrderItemId");

                    b.HasIndex("StocksStockId");

                    b.ToTable("tbl_products");
                });

            modelBuilder.Entity("EntityLayer.Stocks", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"), 1L, 1);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockId");

                    b.ToTable("tbl_stocks");
                });

            modelBuilder.Entity("EntityLayer.SupplierGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("tbl_supplierGroups");
                });

            modelBuilder.Entity("EntityLayer.Suppliers", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SupplierCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierGroupId")
                        .HasColumnType("int");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("SupplierGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_suppliers");
                });

            modelBuilder.Entity("EntityLayer.Tasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("TaskContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TaskCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskCreatorId")
                        .HasColumnType("int");

                    b.Property<int>("TaskOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("TaskStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskCreatorId");

                    b.ToTable("tbl_tasks");
                });

            modelBuilder.Entity("EntityLayer.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("AdminApprove")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OrdersOrderId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("tbl_users");
                });

            modelBuilder.Entity("EntityLayer.Orders", b =>
                {
                    b.HasOne("EntityLayer.OrderItems", null)
                        .WithMany("OrderId")
                        .HasForeignKey("OrderItemsOrderItemId");
                });

            modelBuilder.Entity("EntityLayer.Products", b =>
                {
                    b.HasOne("EntityLayer.OrderItems", null)
                        .WithMany("ProductId")
                        .HasForeignKey("OrderItemsOrderItemId");

                    b.HasOne("EntityLayer.Stocks", null)
                        .WithMany("ProductId")
                        .HasForeignKey("StocksStockId");
                });

            modelBuilder.Entity("EntityLayer.Suppliers", b =>
                {
                    b.HasOne("EntityLayer.SupplierGroup", "SupplierGroup")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Users", "User")
                        .WithMany("Suppliers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupplierGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Tasks", b =>
                {
                    b.HasOne("EntityLayer.Users", "TaskCreator")
                        .WithMany("OwnedTasks")
                        .HasForeignKey("TaskCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskCreator");
                });

            modelBuilder.Entity("EntityLayer.Users", b =>
                {
                    b.HasOne("EntityLayer.Orders", null)
                        .WithMany("CreatedByUserId")
                        .HasForeignKey("OrdersOrderId");
                });

            modelBuilder.Entity("EntityLayer.OrderItems", b =>
                {
                    b.Navigation("OrderId");

                    b.Navigation("ProductId");
                });

            modelBuilder.Entity("EntityLayer.Orders", b =>
                {
                    b.Navigation("CreatedByUserId");
                });

            modelBuilder.Entity("EntityLayer.Stocks", b =>
                {
                    b.Navigation("ProductId");
                });

            modelBuilder.Entity("EntityLayer.SupplierGroup", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("EntityLayer.Users", b =>
                {
                    b.Navigation("OwnedTasks");

                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
