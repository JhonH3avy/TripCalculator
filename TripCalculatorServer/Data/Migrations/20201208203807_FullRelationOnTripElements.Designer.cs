﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TripCalculatorServer.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201208203807_FullRelationOnTripElements")]
    partial class FullRelationOnTripElements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.DayOfWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("DayOfWorks");
                });

            modelBuilder.Entity("Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Entities.TripBag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripBags");
                });

            modelBuilder.Entity("Entities.TripElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DayOfWorkId")
                        .HasColumnType("int");

                    b.Property<int>("TripBagId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayOfWorkId");

                    b.HasIndex("TripBagId");

                    b.ToTable("TripElement");
                });

            modelBuilder.Entity("Entities.TripBag", b =>
                {
                    b.HasOne("Entities.Trip", "Trip")
                        .WithMany("Bags")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Entities.TripElement", b =>
                {
                    b.HasOne("Entities.DayOfWork", "DayOfWork")
                        .WithMany("Elements")
                        .HasForeignKey("DayOfWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.TripBag", "TripBad")
                        .WithMany("Elements")
                        .HasForeignKey("TripBagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOfWork");

                    b.Navigation("TripBad");
                });

            modelBuilder.Entity("Entities.DayOfWork", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("Entities.Trip", b =>
                {
                    b.Navigation("Bags");
                });

            modelBuilder.Entity("Entities.TripBag", b =>
                {
                    b.Navigation("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}
