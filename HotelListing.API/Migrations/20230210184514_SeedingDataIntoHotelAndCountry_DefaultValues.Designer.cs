﻿// <auto-generated />
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListing.API.Migrations
{
    [DbContext(typeof(HotelListingDbContext))]
    [Migration("20230210184514_SeedingDataIntoHotelAndCountry_DefaultValues")]
    partial class SeedingDataIntoHotelAndCountryDefaultValues
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelListing.API.Model.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "United States",
                            ShortName = "US"
                        },
                        new
                        {
                            id = 2,
                            Name = "Australia",
                            ShortName = "AUS"
                        },
                        new
                        {
                            id = 3,
                            Name = "India",
                            ShortName = "IND"
                        },
                        new
                        {
                            id = 4,
                            Name = "Cannada",
                            ShortName = "CAN"
                        });
                });

            modelBuilder.Entity("HotelListing.API.Model.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Address = "Downtown",
                            CountryId = 4,
                            Name = "Adayar Anantha Bhavan",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            id = 2,
                            Address = "Texas",
                            CountryId = 1,
                            Name = "Anjappar",
                            Rating = 4.5
                        },
                        new
                        {
                            id = 3,
                            Address = "Bangalore",
                            CountryId = 3,
                            Name = "Saravana Bhavan",
                            Rating = 4.0
                        },
                        new
                        {
                            id = 4,
                            Address = "Coimbatore",
                            CountryId = 3,
                            Name = "Junior Kuppanna",
                            Rating = 3.0
                        });
                });

            modelBuilder.Entity("HotelListing.API.Model.Hotel", b =>
                {
                    b.HasOne("HotelListing.API.Model.Country", "Country")
                        .WithMany("Hotel")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelListing.API.Model.Country", b =>
                {
                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
