﻿// <auto-generated />
using System;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeterTest.MigrationDirectory1
{
    [DbContext(typeof(CustomizationTableDbContext))]
    [Migration("20210831020718_migration_name")]
    partial class migration_name
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("MeterTest.Source.Dlt645.DataId", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomizationTableName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("DataArray")
                        .HasColumnType("BLOB");

                    b.Property<int>("DataBytes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Format")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWritable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomizationTableName");

                    b.ToTable("DataId");
                });

            modelBuilder.Entity("MeterTest.Source.SQLite.CustomizationTable", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Name")
                        .HasName("PrimaryKey_Name");

                    b.ToTable("CustomizationTables");
                });

            modelBuilder.Entity("MeterTest.Source.Dlt645.DataId", b =>
                {
                    b.HasOne("MeterTest.Source.SQLite.CustomizationTable", null)
                        .WithMany("DataId")
                        .HasForeignKey("CustomizationTableName");
                });

            modelBuilder.Entity("MeterTest.Source.SQLite.CustomizationTable", b =>
                {
                    b.Navigation("DataId");
                });
#pragma warning restore 612, 618
        }
    }
}
