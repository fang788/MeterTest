﻿// <auto-generated />
using System;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeterTest.Migrations
{
    [DbContext(typeof(DataIdDbContext))]
    [Migration("20211208082643_InitialCreate")]
    partial class InitialCreate
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

                    b.ToTable("DataIds");
                });
#pragma warning restore 612, 618
        }
    }
}
