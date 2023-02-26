﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using primerParcial.Models;

#nullable disable

namespace primerParcial.Migrations
{
    [DbContext(typeof(VideojuegosDbContext))]
    [Migration("20221115225335_AgregoModeloGeneroAct")]
    partial class AgregoModeloGeneroAct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeneroVideojuego", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.Property<int>("VideojuegosId")
                        .HasColumnType("int");

                    b.HasKey("GenerosId", "VideojuegosId");

                    b.HasIndex("VideojuegosId");

                    b.ToTable("GeneroVideojuego");
                });

            modelBuilder.Entity("primerParcial.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("primerParcial.Models.Plataforma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plataformas");
                });

            modelBuilder.Entity("primerParcial.Models.Videojuego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Desarrollador")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("FechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Multijugador")
                        .HasColumnType("bit");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("PuntajeMetacritic")
                        .HasColumnType("int");

                    b.Property<bool>("TieneLogros")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Videojuegos");
                });

            modelBuilder.Entity("GeneroVideojuego", b =>
                {
                    b.HasOne("primerParcial.Models.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("primerParcial.Models.Videojuego", null)
                        .WithMany()
                        .HasForeignKey("VideojuegosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("primerParcial.Models.Videojuego", b =>
                {
                    b.HasOne("primerParcial.Models.Plataforma", "Plataforma")
                        .WithMany("Videojuegos")
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("primerParcial.Models.Plataforma", b =>
                {
                    b.Navigation("Videojuegos");
                });
#pragma warning restore 612, 618
        }
    }
}
