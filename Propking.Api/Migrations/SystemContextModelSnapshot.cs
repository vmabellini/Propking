﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Propking.Api.Data;

namespace Propking.Api.Migrations
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Propking.Api.Models.Fii", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryTag");

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Fii");
                });

            modelBuilder.Entity("Propking.Api.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FiiId");

                    b.HasKey("Id");

                    b.HasIndex("FiiId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Propking.Api.Models.PositionChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChangeType");

                    b.Property<int>("FiiId");

                    b.Property<int?>("PositionId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitValue");

                    b.HasKey("Id");

                    b.HasIndex("FiiId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionChange");
                });

            modelBuilder.Entity("Propking.Api.Models.Position", b =>
                {
                    b.HasOne("Propking.Api.Models.Fii", "Fii")
                        .WithMany()
                        .HasForeignKey("FiiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propking.Api.Models.PositionChange", b =>
                {
                    b.HasOne("Propking.Api.Models.Fii", "Fii")
                        .WithMany()
                        .HasForeignKey("FiiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Propking.Api.Models.Position")
                        .WithMany("Changes")
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
