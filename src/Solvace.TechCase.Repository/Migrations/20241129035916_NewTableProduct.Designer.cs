﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solvace.TechCase.Repository.Contexts;

#nullable disable

namespace Solvace.TechCase.Repository.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241129035916_NewTableProduct")]
    partial class NewTableProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Solvace.TechCase.Domain.Entities.ActionPlan.ActionPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ActionPlanStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("EndedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActionPlanStatusId");

                    b.ToTable("ActionPlans");
                });

            modelBuilder.Entity("Solvace.TechCase.Domain.Entities.ActionPlan.ActionPlanStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ActionPlanStatus");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7692), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalId = "ced0d0a2-24b6-428a-8f83-736f78ebb65c",
                            IsActive = true,
                            Name = "OPEN"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalId = "9a9a147c-cb8b-4bb6-b683-0690a43689fc",
                            IsActive = true,
                            Name = "IN_PROGRESS"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7824), new TimeSpan(0, 0, 0, 0, 0)),
                            ExternalId = "42da6666-0a9d-4249-9655-f924ed681968",
                            IsActive = true,
                            Name = "COMPLETED"
                        });
                });

            modelBuilder.Entity("Solvace.TechCase.Domain.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Solvace.TechCase.Domain.Entities.ActionPlan.ActionPlan", b =>
                {
                    b.HasOne("Solvace.TechCase.Domain.Entities.ActionPlan.ActionPlanStatus", "ActionPlanStatus")
                        .WithMany()
                        .HasForeignKey("ActionPlanStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionPlanStatus");
                });
#pragma warning restore 612, 618
        }
    }
}