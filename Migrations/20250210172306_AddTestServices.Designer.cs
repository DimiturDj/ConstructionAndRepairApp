﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairAndConstructionService.Data;

#nullable disable

namespace RepairAndConstructionService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250210172306_AddTestServices")]
    partial class AddTestServices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RepairAndConstructionService.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alice@mail.com",
                            Name = "Alice Johnson",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@mail.com",
                            Name = "Bob Williams",
                            PhoneNumber = "0987654321"
                        });
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("JobOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fix wiring and installations",
                            Price = 150m,
                            Title = "Electrical Repair"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fix plumbing issues",
                            Price = 200m,
                            Title = "Plumbing Repair"
                        });
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fix leaks and damage on your roof.",
                            Price = 500m,
                            Title = "Roof Repair"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Install new plumbing and fix water system issues.",
                            Price = 150m,
                            Title = "Plumbing"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Interior and exterior painting services.",
                            Price = 300m,
                            Title = "Painting"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Electrical installations and repair.",
                            Price = 200m,
                            Title = "Electrician"
                        });
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dimitur Djerov",
                            Rating = 4.5,
                            Specialization = "Electrician"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Smith",
                            Rating = 4.7999999999999998,
                            Specialization = "Plumber"
                        });
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Booking", b =>
                {
                    b.HasOne("RepairAndConstructionService.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairAndConstructionService.Models.JobOffer", "JobOffer")
                        .WithMany()
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairAndConstructionService.Models.Worker", "Worker")
                        .WithMany("Bookings")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Customer");

                    b.Navigation("JobOffer");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.JobOffer", b =>
                {
                    b.HasOne("RepairAndConstructionService.Models.Worker", null)
                        .WithMany("JobOffers")
                        .HasForeignKey("WorkerId");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Review", b =>
                {
                    b.HasOne("RepairAndConstructionService.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairAndConstructionService.Models.Worker", "Worker")
                        .WithMany("Reviews")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("RepairAndConstructionService.Models.Worker", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("JobOffers");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
