﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wepApi.Models;

#nullable disable

namespace wepApi.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20240328124819_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("wepApi.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("_products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coffy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Television"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pencil"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
