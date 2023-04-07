﻿// <auto-generated />
using System;
using Maskan.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Maskan.Migrations
{
    [DbContext(typeof(MaskanContext))]
    [Migration("20230407222410_addAddress")]
    partial class addAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Maskan.Models.Admin", b =>
                {
                    b.Property<long>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AdminID"), 1L, 1);

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Maskan.Models.Buyer", b =>
                {
                    b.Property<long>("BuyerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BuyerID"), 1L, 1);

                    b.Property<string>("BuyerAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BuyerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("NationalID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerID");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Maskan.Models.Category", b =>
                {
                    b.Property<long>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Maskan.Models.CategoryGroup", b =>
                {
                    b.Property<int>("CategoryGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryGroupID"), 1L, 1);

                    b.Property<long?>("CategoryID")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropertyID")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryGroupID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PropertyID");

                    b.ToTable("CategoryGroups");
                });

            modelBuilder.Entity("Maskan.Models.Deal", b =>
                {
                    b.Property<long>("DealID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DealID"), 1L, 1);

                    b.Property<long>("BuyerID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("DealTypeID")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("SellerID")
                        .HasColumnType("bigint");

                    b.HasKey("DealID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("DealTypeID");

                    b.HasIndex("SellerID");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("Maskan.Models.DealType", b =>
                {
                    b.Property<long>("DealTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DealTypeID"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DealTypeID");

                    b.ToTable("DealTypes");
                });

            modelBuilder.Entity("Maskan.Models.Images", b =>
                {
                    b.Property<long>("ImagesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ImagesID"), 1L, 1);

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PropertyID")
                        .HasColumnType("bigint");

                    b.HasKey("ImagesID");

                    b.HasIndex("PropertyID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Maskan.Models.Property", b =>
                {
                    b.Property<long>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PropertyID"), 1L, 1);

                    b.Property<long>("Area")
                        .HasColumnType("bigint");

                    b.Property<long>("BathsNum")
                        .HasColumnType("bigint");

                    b.Property<long>("BedsNum")
                        .HasColumnType("bigint");

                    b.Property<long>("DealTypeID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Furnished")
                        .HasColumnType("bit");

                    b.Property<string>("GoogleMapsLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoomsNum")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VrLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyID");

                    b.HasIndex("DealTypeID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Maskan.Models.Seller", b =>
                {
                    b.Property<long>("SellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SellerID"), 1L, 1);

                    b.Property<decimal>("NationalID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SellerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SellerID");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Maskan.Models.CategoryGroup", b =>
                {
                    b.HasOne("Maskan.Models.Category", "Category")
                        .WithMany("CategoryGroups")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Maskan.Models.Property", "Property")
                        .WithMany("CategoryGroups")
                        .HasForeignKey("PropertyID");

                    b.Navigation("Category");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Maskan.Models.Deal", b =>
                {
                    b.HasOne("Maskan.Models.Buyer", "Buyer")
                        .WithMany("Deals")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Maskan.Models.DealType", "DealType")
                        .WithMany("Deals")
                        .HasForeignKey("DealTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Maskan.Models.Seller", "Seller")
                        .WithMany("Deals")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("DealType");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Maskan.Models.Images", b =>
                {
                    b.HasOne("Maskan.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyID");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Maskan.Models.Property", b =>
                {
                    b.HasOne("Maskan.Models.DealType", "DealType")
                        .WithMany("Properties")
                        .HasForeignKey("DealTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DealType");
                });

            modelBuilder.Entity("Maskan.Models.Buyer", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("Maskan.Models.Category", b =>
                {
                    b.Navigation("CategoryGroups");
                });

            modelBuilder.Entity("Maskan.Models.DealType", b =>
                {
                    b.Navigation("Deals");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Maskan.Models.Property", b =>
                {
                    b.Navigation("CategoryGroups");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Maskan.Models.Seller", b =>
                {
                    b.Navigation("Deals");
                });
#pragma warning restore 612, 618
        }
    }
}
