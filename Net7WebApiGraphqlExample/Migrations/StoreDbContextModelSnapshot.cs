﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net7WebApiGraphqlExample.Data;

#nullable disable

namespace Net7WebApiGraphqlExample.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<DateTime>("AccountDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AccountEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AccountStatus")
                        .HasColumnType("bit");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OrderStatus")
                        .HasColumnType("bit");

                    b.HasKey("OrderId");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<DateTime>("OrderDetailDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderDetailName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderDetailPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderDetailQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("OrderDetailStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.Product", b =>
                {
                    b.Property<int?>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProductId"));

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductSku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ProductStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ProductUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.Order", b =>
                {
                    b.HasOne("Net7WebApiGraphqlExample.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.OrderDetail", b =>
                {
                    b.HasOne("Net7WebApiGraphqlExample.Entities.Order", "Order")
                        .WithMany("orderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net7WebApiGraphqlExample.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Net7WebApiGraphqlExample.Entities.Order", b =>
                {
                    b.Navigation("orderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
