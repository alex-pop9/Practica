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
    [Migration("20240802062134_Reservation")]
    partial class Reservation
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
                    b.Property<int>("ConfigurationLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfigurationString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeStamp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConfigurationLogID");

                    b.ToTable("ConfigurationLog");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.FileSettings", b =>
                {
                    b.Property<int>("FileSettingsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FileSettingsID");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.PathConfigurationLog", b =>
                {
                    b.Property<int>("PathConfigurationLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConfigurationLogID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FileSettingsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PathConfigurationLogID");

                    b.HasIndex("ConfigurationLogID");

                    b.HasIndex("FileSettingsID");

                    b.ToTable("PathConfigurationLog");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfirmedTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Distance")
                        .HasColumnType("REAL");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<float>("PricePerKm")
                        .HasColumnType("REAL");

                    b.Property<int>("Week")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.PathConfigurationLog", b =>
                {
                    b.HasOne("ProiectPractica.DbModel.ConfigurationLog", "ConfigurationLog")
                        .WithMany("PathConfigurations")
                        .HasForeignKey("ConfigurationLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectPractica.DbModel.FileSettings", "FileSettings")
                        .WithMany("PathConfigurations")
                        .HasForeignKey("FileSettingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigurationLog");

                    b.Navigation("FileSettings");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.ConfigurationLog", b =>
                {
                    b.Navigation("PathConfigurations");
                });

            modelBuilder.Entity("ProiectPractica.DbModel.FileSettings", b =>
                {
                    b.Navigation("PathConfigurations");
                });
#pragma warning restore 612, 618
        }
    }
}
