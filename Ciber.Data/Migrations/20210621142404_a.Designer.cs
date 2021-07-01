﻿// <auto-generated />
using System;
using Ciber.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ciber.Data.Migrations
{
    [DbContext(typeof(CiberDbContext))]
    [Migration("20210621142404_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ciber.Data.Enititys.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A1,A2,A3,A4",
                            Name = "Paper"
                        },
                        new
                        {
                            ID = 2,
                            Description = "pencil",
                            Name = "Pencil"
                        });
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cutomers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "HaNoi",
                            Name = "Thanh Tu",
                            Password = "123"
                        },
                        new
                        {
                            ID = 2,
                            Address = "HaNoi",
                            Name = "Tuan Tu",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Amount = 2,
                            CustomerID = 1,
                            OrderDate = new DateTime(2021, 6, 21, 21, 24, 4, 51, DateTimeKind.Local).AddTicks(9064),
                            ProductID = 1
                        },
                        new
                        {
                            ID = 2,
                            Amount = 32,
                            CustomerID = 1,
                            OrderDate = new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5932),
                            ProductID = 2
                        },
                        new
                        {
                            ID = 3,
                            Amount = 11,
                            CustomerID = 2,
                            OrderDate = new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5954),
                            ProductID = 3
                        });
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            Description = "A4 Canon Description",
                            Name = "A4 Canon",
                            Price = 10000m,
                            Quantity = 100
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 1,
                            Description = "A4 Casio Description",
                            Name = "A4 Casio",
                            Price = 14000m,
                            Quantity = 10
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 2,
                            Description = "Pencil Description",
                            Name = "Pencil 1",
                            Price = 15000m,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Order", b =>
                {
                    b.HasOne("Ciber.Data.Enititys.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ciber.Data.Enititys.Product", "Product")
                        .WithMany("Order")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Product", b =>
                {
                    b.HasOne("Ciber.Data.Enititys.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Ciber.Data.Enititys.Product", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
