﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.DAL;

#nullable disable

namespace Order.DAL.Migrations
{
    [DbContext(typeof(MyTransporterOrderContext))]
    [Migration("20220525124348_AddedVehicleTable")]
    partial class AddedVehicleTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Order.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chernivtsi",
                            RegionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Novoselitsa",
                            RegionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lviv",
                            RegionId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Truskavets",
                            RegionId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kyiv",
                            RegionId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Borispol",
                            RegionId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bila Tserkva",
                            RegionId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "Warsaw",
                            RegionId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Radom",
                            RegionId = 4
                        },
                        new
                        {
                            Id = 10,
                            Name = "Krakow",
                            RegionId = 5
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tarnow",
                            RegionId = 5
                        },
                        new
                        {
                            Id = 12,
                            Name = "Berlin",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 13,
                            Name = "Wiesbaden",
                            RegionId = 7
                        },
                        new
                        {
                            Id = 14,
                            Name = "Frankfurt",
                            RegionId = 7
                        },
                        new
                        {
                            Id = 15,
                            Name = "Paris",
                            RegionId = 8
                        },
                        new
                        {
                            Id = 16,
                            Name = "Marseille",
                            RegionId = 9
                        },
                        new
                        {
                            Id = 17,
                            Name = "Siret",
                            RegionId = 10
                        },
                        new
                        {
                            Id = 18,
                            Name = "Suceava",
                            RegionId = 10
                        },
                        new
                        {
                            Id = 19,
                            Name = "Bucuresti",
                            RegionId = 11
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Poland"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 4,
                            Name = "France"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romania"
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Journeys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2022, 3, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 16, 5, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2022, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 17, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2022, 3, 19, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 19, 4, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JourneyId");

                    b.HasIndex("RouteId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            JourneyId = 1,
                            OrderDate = new DateTime(2022, 3, 15, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 3,
                            RouteId = 3,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            JourneyId = 2,
                            OrderDate = new DateTime(2022, 3, 16, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 3,
                            RouteId = 5,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            JourneyId = 3,
                            OrderDate = new DateTime(2022, 3, 18, 12, 35, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 3,
                            RouteId = 7,
                            VehicleId = 2
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Chernivtsi Oblast"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Lviv Oblast"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Kyiv Oblast"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Mazowieckie"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Malopolskie"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 3,
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 3,
                            Name = "Hessen"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 4,
                            Name = "Île-de-France"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 4,
                            Name = "Provence-Alpes-Cote d'Azur"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 5,
                            Name = "Suceava"
                        },
                        new
                        {
                            Id = 11,
                            CountryId = 5,
                            Name = "Bucuresti"
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EndPointId")
                        .HasColumnType("int");

                    b.Property<int?>("StartPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndPointId");

                    b.HasIndex("StartPointId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndPointId = 2,
                            StartPointId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndPointId = 1,
                            StartPointId = 2
                        },
                        new
                        {
                            Id = 3,
                            EndPointId = 3,
                            StartPointId = 1
                        },
                        new
                        {
                            Id = 4,
                            EndPointId = 1,
                            StartPointId = 3
                        },
                        new
                        {
                            Id = 5,
                            EndPointId = 5,
                            StartPointId = 1
                        },
                        new
                        {
                            Id = 6,
                            EndPointId = 1,
                            StartPointId = 5
                        },
                        new
                        {
                            Id = 7,
                            EndPointId = 12,
                            StartPointId = 1
                        },
                        new
                        {
                            Id = 8,
                            EndPointId = 1,
                            StartPointId = 12
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Plate")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Order.DAL.Entities.City", b =>
                {
                    b.HasOne("Order.DAL.Entities.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Order.DAL.Entities.Order", b =>
                {
                    b.HasOne("Order.DAL.Entities.Journey", "Journey")
                        .WithMany("Orders")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Order.DAL.Entities.Route", "Route")
                        .WithMany("Orders")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journey");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Order.DAL.Entities.Region", b =>
                {
                    b.HasOne("Order.DAL.Entities.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Order.DAL.Entities.Route", b =>
                {
                    b.HasOne("Order.DAL.Entities.City", "EndPoint")
                        .WithMany("EndPoints")
                        .HasForeignKey("EndPointId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Order.DAL.Entities.City", "StartPoint")
                        .WithMany("StartPoints")
                        .HasForeignKey("StartPointId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("EndPoint");

                    b.Navigation("StartPoint");
                });

            modelBuilder.Entity("Order.DAL.Entities.City", b =>
                {
                    b.Navigation("EndPoints");

                    b.Navigation("StartPoints");
                });

            modelBuilder.Entity("Order.DAL.Entities.Country", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("Order.DAL.Entities.Journey", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Order.DAL.Entities.Region", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Order.DAL.Entities.Route", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
