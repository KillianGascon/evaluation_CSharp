﻿// <auto-generated />
using System;
using Geometrie.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Geometrie.DAL.Migrations
{
    [DbContext(typeof(GeometrieContext))]
    [Migration("20241218144819_ModifCercle")]
    partial class ModifCercle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Geometrie.DAL.Cercle_DAL", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("CentreId")
                        .HasColumnType("int");

                    b.Property<double>("Rayon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CentreId");

                    b.ToTable("Cercles");
                });

            modelBuilder.Entity("Geometrie.DAL.Log_DAL", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateAppel")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(39)
                        .HasColumnType("nvarchar(39)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Geometrie.DAL.Point_DAL", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateDeCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeModification")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PolygoneId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolygoneId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Geometrie.DAL.Polygone", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("DateDeCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeModification")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Polygone");
                });

            modelBuilder.Entity("Geometrie.DAL.Cercle_DAL", b =>
                {
                    b.HasOne("Geometrie.DAL.Point_DAL", "Centre")
                        .WithMany()
                        .HasForeignKey("CentreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Centre");
                });

            modelBuilder.Entity("Geometrie.DAL.Point_DAL", b =>
                {
                    b.HasOne("Geometrie.DAL.Polygone", "Polygone")
                        .WithMany("Points")
                        .HasForeignKey("PolygoneId");

                    b.Navigation("Polygone");
                });

            modelBuilder.Entity("Geometrie.DAL.Polygone", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
