﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEP3_TIER3.Database;

namespace SEP3_TIER3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEP3_TIER3.Model.Edge", b =>
                {
                    b.Property<int>("EdgeId")
                        .HasColumnType("int");

                    b.Property<int>("FromNodeIndex")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("ToNodeIndex")
                        .HasColumnType("int");

                    b.HasKey("EdgeId");

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.FlightPlan", b =>
                {
                    b.Property<string>("CallSign")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ArrivalTimeHour")
                        .HasColumnType("int");

                    b.Property<int?>("ArrivalTimeMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("ArrivalTimeSeconds")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureTimeHour")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureTimeMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureTimeSeconds")
                        .HasColumnType("int");

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallSign", "FlightNumber");

                    b.HasIndex("ArrivalTimeHour", "ArrivalTimeMinutes", "ArrivalTimeSeconds");

                    b.HasIndex("DepartureTimeHour", "DepartureTimeMinutes", "DepartureTimeSeconds");

                    b.ToTable("FlightPlans");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.Property<int>("DistanceFromSource")
                        .HasColumnType("int");

                    b.Property<bool>("IsGroundNode")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisited")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PositionXCoordinate")
                        .HasColumnType("float");

                    b.Property<double>("PositionYCoordinate")
                        .HasColumnType("float");

                    b.HasKey("NodeId");

                    b.HasIndex("PositionXCoordinate", "PositionYCoordinate");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.NodeEdge", b =>
                {
                    b.Property<int>("EdgeId")
                        .HasColumnType("int");

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.HasKey("EdgeId", "NodeId");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeEdges");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Plane", b =>
                {
                    b.Property<string>("RegistrationNo")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightPlanCallSign")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FlightPlanFlightNumber")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PlanePositionXCoordinate")
                        .HasColumnType("float");

                    b.Property<double>("PlanePositionYCoordinate")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegistrationNo");

                    b.HasIndex("FlightPlanCallSign", "FlightPlanFlightNumber");

                    b.HasIndex("PlanePositionXCoordinate", "PlanePositionYCoordinate");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Position", b =>
                {
                    b.Property<double>("XCoordinate")
                        .HasColumnType("float");

                    b.Property<double>("YCoordinate")
                        .HasColumnType("float");

                    b.HasKey("XCoordinate", "YCoordinate");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Timer", b =>
                {
                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hour", "Minutes", "Seconds");

                    b.ToTable("Timer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Timer");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.FlightDate", b =>
                {
                    b.HasBaseType("SEP3_TIER3.Model.Timer");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("FlightDate");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.FlightPlan", b =>
                {
                    b.HasOne("SEP3_TIER3.Model.FlightDate", "ArrivalTime")
                        .WithMany()
                        .HasForeignKey("ArrivalTimeHour", "ArrivalTimeMinutes", "ArrivalTimeSeconds");

                    b.HasOne("SEP3_TIER3.Model.FlightDate", "DepartureTime")
                        .WithMany()
                        .HasForeignKey("DepartureTimeHour", "DepartureTimeMinutes", "DepartureTimeSeconds");
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Node", b =>
                {
                    b.HasOne("SEP3_TIER3.Model.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionXCoordinate", "PositionYCoordinate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SEP3_TIER3.Model.NodeEdge", b =>
                {
                    b.HasOne("SEP3_TIER3.Model.Edge", "Edge")
                        .WithMany("NodeEdges")
                        .HasForeignKey("EdgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEP3_TIER3.Model.Node", "Node")
                        .WithMany("NodeEdges")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SEP3_TIER3.Model.Plane", b =>
                {
                    b.HasOne("SEP3_TIER3.Model.FlightPlan", "FlightPlan")
                        .WithMany()
                        .HasForeignKey("FlightPlanCallSign", "FlightPlanFlightNumber");

                    b.HasOne("SEP3_TIER3.Model.Position", "PlanePosition")
                        .WithMany()
                        .HasForeignKey("PlanePositionXCoordinate", "PlanePositionYCoordinate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
