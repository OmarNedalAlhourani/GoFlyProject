﻿// <auto-generated />
using System;
using GoFly.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoFly.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231013154255_Omar546")]
    partial class Omar546
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoFly.BL.Models.BlogPage.OurBlog", b =>
                {
                    b.Property<int>("OurBlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OurBlogId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OurBlogId");

                    b.ToTable("OurBlogs");
                });

            modelBuilder.Entity("GoFly.BL.Models.CarPage.CarRent", b =>
                {
                    b.Property<int>("CarRentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarRentId"));

                    b.Property<string>("CarRentTitel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("PriseDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriseMonth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriseWeek")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CarRentId");

                    b.ToTable("CarRents");
                });

            modelBuilder.Entity("GoFly.BL.Models.ContactPage.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserMassage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GoFly.BL.Models.ContactPage.OurAddress", b =>
                {
                    b.Property<int>("OurAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OurAddressId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OurAddressId");

                    b.ToTable("OurAddresses");
                });

            modelBuilder.Entity("GoFly.BL.Models.HomePage.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("GoFly.BL.Models.HomePage.HotTour", b =>
                {
                    b.Property<int>("HotTourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotTourId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HotTourDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotTourName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HotTourPrise")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("TitelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotTourId");

                    b.ToTable("HotTours");
                });

            modelBuilder.Entity("GoFly.BL.Models.HomePage.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerentId")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("GoFly.BL.Models.HomePage.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("PlanDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanTitel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlanId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("GoFly.BL.Models.HomePage.PopularDestination", b =>
                {
                    b.Property<int>("PopularDestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PopularDestinationId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("PopularDestinationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PopularDestinationId");

                    b.ToTable("PopularDestinations");
                });

            modelBuilder.Entity("GoFly.BL.Models.HotelPage.HostelDestination", b =>
                {
                    b.Property<int>("HostelDestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HostelDestinationId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HostelDestinationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostelDestinationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HostelDestinationPrise")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("TitelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HostelDestinationId");

                    b.ToTable("HostelDestinations");
                });

            modelBuilder.Entity("GoFly.BL.Models.HotelPage.TravelBooking", b =>
                {
                    b.Property<int>("TravelBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TravelBookingId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<string>("TravelBookingDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TravelBookingId");

                    b.ToTable("TravelBookings");
                });

            modelBuilder.Entity("GoFly.BL.Models.vacationPage.TouristSpots", b =>
                {
                    b.Property<int>("TouristSpotsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TouristSpotsId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Prise")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TouristSpotsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TouristSpotsTitel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TouristSpotsId");

                    b.ToTable("TouristSpotes");
                });
#pragma warning restore 612, 618
        }
    }
}