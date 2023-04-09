﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckManager.Infrastructure.Persistence;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    [DbContext(typeof(TruckManagerDbContext))]
    partial class TruckManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TruckManager.Domain.TruckAggregate.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuelTankSize")
                        .HasColumnType("int");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VeichleAllowenceExperationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trucks", (string)null);
                });

            modelBuilder.Entity("TruckManager.Domain.TruckAggregate.Truck", b =>
                {
                    b.OwnsMany("TruckManager.Domain.TruckAggregate.Entities.TruckIncident", "Incidents", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TruckIncidentId");

                            b1.Property<Guid>("TruckId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("Id", "TruckId");

                            b1.HasIndex("TruckId");

                            b1.ToTable("TruckIncidents", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TruckId");
                        });

                    b.OwnsMany("TruckManager.Domain.TruckAggregate.Entities.TruckTanking", "Tankings", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TruckTankingId");

                            b1.Property<Guid>("TruckId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Quantiy")
                                .HasColumnType("int");

                            b1.HasKey("Id", "TruckId");

                            b1.HasIndex("TruckId");

                            b1.ToTable("TruckTankings", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TruckId");

                            b1.OwnsOne("TruckManager.Domain.Common.ValueObjects.Cost", "Cost", b2 =>
                                {
                                    b2.Property<Guid>("TruckTankingId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("TruckTankingTruckId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<double>("Amount")
                                        .HasColumnType("float");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("TruckTankingId", "TruckTankingTruckId");

                                    b2.ToTable("TruckTankings");

                                    b2.WithOwner()
                                        .HasForeignKey("TruckTankingId", "TruckTankingTruckId");
                                });

                            b1.Navigation("Cost")
                                .IsRequired();
                        });

                    b.Navigation("Incidents");

                    b.Navigation("Tankings");
                });
#pragma warning restore 612, 618
        }
    }
}
