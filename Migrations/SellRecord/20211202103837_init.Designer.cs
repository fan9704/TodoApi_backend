﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi_backend.Data;

namespace TodoApi_backend.Migrations.SellRecord
{
    [DbContext(typeof(SellRecordContext))]
    [Migration("20211202103837_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("TodoApi_backend.Models.SellRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Profit")
                        .HasColumnType("longtext");

                    b.Property<string>("SellDate")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("sell_quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SellRecord");
                });
#pragma warning restore 612, 618
        }
    }
}