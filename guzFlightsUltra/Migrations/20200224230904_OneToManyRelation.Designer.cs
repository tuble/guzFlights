﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using guzFlights.Data;

namespace guzFlightsUltra.Migrations
{
    [DbContext(typeof(guzFlightsUltraDbContext))]
    [Migration("20200224230904_OneToManyRelation")]
    partial class OneToManyRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("guzFlightsUltra.Data.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BussinessCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("EndDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PilotName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaneId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaneType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TakeOffTime")
                        .HasColumnType("datetime2");

                    b.HasKey("FlightId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("guzFlightsUltra.Data.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.HasKey("PassengerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("guzFlightsUltra.Data.Models.Reservation", b =>
                {
                    b.Property<int>("ReservatoionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ReservatoionId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("guzFlightsUltra.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("guzFlightsUltra.Data.Models.Flight", b =>
                {
                    b.HasOne("guzFlightsUltra.Data.Models.Reservation", "FlightReservation")
                        .WithMany("Flights")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("guzFlightsUltra.Data.Models.Passenger", b =>
                {
                    b.HasOne("guzFlightsUltra.Data.Models.Reservation", "FlightReservation")
                        .WithMany("Passengers")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
