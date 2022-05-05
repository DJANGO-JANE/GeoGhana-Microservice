﻿// <auto-generated />
using Ghana.Services.DivisionsAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ghana.Services.DivisionsAPI.Migrations
{
    [DbContext(typeof(DivisionContext))]
    [Migration("20220505173926_SeededRegions")]
    partial class SeededRegions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.City", b =>
                {
                    b.Property<int>("CityCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RegionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CityCode");

                    b.HasIndex("RegionCode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.Locality", b =>
                {
                    b.Property<int>("ConstID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityCode")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LocalityCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegionCode")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ConstID");

                    b.HasIndex("CityCode");

                    b.HasIndex("RegionCode");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.Region", b =>
                {
                    b.Property<string>("RegionCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CapitalCity")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("RegionCode");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            RegionCode = "ASX",
                            CapitalCity = "Kumasi",
                            Name = "Ashanti"
                        },
                        new
                        {
                            RegionCode = "GRX",
                            CapitalCity = "Accra",
                            Name = "Greater Accra"
                        },
                        new
                        {
                            RegionCode = "BNX",
                            CapitalCity = "Sunyani",
                            Name = "Bono Region"
                        },
                        new
                        {
                            RegionCode = "BEX",
                            CapitalCity = "Techiman",
                            Name = "Bono East Region"
                        },
                        new
                        {
                            RegionCode = "HAX",
                            CapitalCity = "Goaso",
                            Name = "Ahafo Region"
                        },
                        new
                        {
                            RegionCode = "CNX",
                            CapitalCity = "Cape Coast",
                            Name = "Central"
                        },
                        new
                        {
                            RegionCode = "EAX",
                            CapitalCity = "Koforidua",
                            Name = "Eastern"
                        },
                        new
                        {
                            RegionCode = "NRX",
                            CapitalCity = "Tamale",
                            Name = "Northern"
                        },
                        new
                        {
                            RegionCode = "SVX",
                            CapitalCity = "Damongo",
                            Name = "Savannah"
                        },
                        new
                        {
                            RegionCode = "NEX",
                            CapitalCity = "Nalerigu",
                            Name = "North East"
                        },
                        new
                        {
                            RegionCode = "UWX",
                            CapitalCity = "Wa",
                            Name = "Upper West"
                        },
                        new
                        {
                            RegionCode = "UEX",
                            CapitalCity = "Bolgatanga",
                            Name = "Upper East"
                        },
                        new
                        {
                            RegionCode = "VLX",
                            CapitalCity = "Ho",
                            Name = "Volta Region"
                        },
                        new
                        {
                            RegionCode = "OTX",
                            CapitalCity = "Dambai",
                            Name = "Oti"
                        },
                        new
                        {
                            RegionCode = "WSX",
                            CapitalCity = "Takoradi",
                            Name = "Western Region"
                        },
                        new
                        {
                            RegionCode = "WNX",
                            CapitalCity = "Wiawso",
                            Name = "Western North"
                        });
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.City", b =>
                {
                    b.HasOne("Ghana.Services.DivisionsAPI.Models.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.Locality", b =>
                {
                    b.HasOne("Ghana.Services.DivisionsAPI.Models.City", "City")
                        .WithMany("Localities")
                        .HasForeignKey("CityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ghana.Services.DivisionsAPI.Models.Region", "Region")
                        .WithMany("Localities")
                        .HasForeignKey("RegionCode");

                    b.Navigation("City");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.City", b =>
                {
                    b.Navigation("Localities");
                });

            modelBuilder.Entity("Ghana.Services.DivisionsAPI.Models.Region", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Localities");
                });
#pragma warning restore 612, 618
        }
    }
}
