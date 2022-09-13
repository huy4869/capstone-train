﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication3.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20220913044214_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("WebApplication3.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("countryCode")
                        .HasColumnType("longtext");

                    b.Property<string>("district")
                        .HasColumnType("longtext");

                    b.Property<int>("population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("City");
                });
#pragma warning restore 612, 618
        }
    }
}
