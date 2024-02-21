﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SADBLTrainingReport.Data;

#nullable disable

namespace SADBLTrainingReport.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240220103429_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SADBLTrainingReport.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("organizerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sdbl_organizer");
                });

            modelBuilder.Entity("SADBLTrainingReport.Models.ProgramName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("programName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sdbl_programName");
                });

            modelBuilder.Entity("SADBLTrainingReport.Models.TargetGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("targetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sdbl_tagregtGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
