﻿// <auto-generated />
using System;
using EFCoreConsoleAppla.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace net6MVCCRUD.Migrations
{
    [DbContext(typeof(AdsPumaDbContext))]
    partial class AdsPumaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("資料庫備註");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("我是name");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Customerid")
                        .HasColumnType("int");

                    b.Property<int>("Customerld")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderFulfilled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Customerid");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.ProductOrder", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<int>("Orderid")
                        .HasColumnType("int");

                    b.Property<int>("Orderld")
                        .HasColumnType("int");

                    b.Property<int>("Productld")
                        .HasColumnType("int");

                    b.Property<int>("Queantity")
                        .HasColumnType("int");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.HasIndex("productid");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Order", b =>
                {
                    b.HasOne("EFCoreConsoleAppla.Models.Customer", "Customer")
                        .WithMany("Orsers")
                        .HasForeignKey("Customerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.ProductOrder", b =>
                {
                    b.HasOne("EFCoreConsoleAppla.Models.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("Orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreConsoleAppla.Models.Product", "product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Customer", b =>
                {
                    b.Navigation("Orsers");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("EFCoreConsoleAppla.Models.Product", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
