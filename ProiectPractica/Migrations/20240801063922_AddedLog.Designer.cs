﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectPractica.Persistance;

#nullable disable

namespace ProiectPractica.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    [Migration("20240801063922_AddedLog")]
    partial class AddedLog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("ProiectPractica.DbModel.Configuration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndBusinessHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinAcceptablePrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinPriceForShortTrips")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MinPricePerKm")
                        .HasColumnType("REAL");

                    b.Property<int>("NumberOfCars")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservationCheckInterval")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShortTripDistanceThreshold")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartBusinessHour")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.ConfigurationLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfigurationString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeStamp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("ConfigurationLog");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.FileSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.PathConfigurationLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("idConfiguration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idPath")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("PathConfigurationLog");
                });
#pragma warning restore 612, 618
        }
    }
}
