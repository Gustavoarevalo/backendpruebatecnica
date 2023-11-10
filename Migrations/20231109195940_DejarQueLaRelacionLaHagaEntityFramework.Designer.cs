﻿// <auto-generated />
using System;
using DatosPruebaTecnica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendPruebatecnica.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231109195940_DejarQueLaRelacionLaHagaEntityFramework")]
    partial class DejarQueLaRelacionLaHagaEntityFramework
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatosPruebaTecnica.Models.DetalleFactura", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItem"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdFactura")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.HasKey("IdItem");

                    b.HasIndex("IdFactura");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IGV")
                        .HasColumnType("int");

                    b.Property<int?>("NumerodeFactura")
                        .HasColumnType("int");

                    b.Property<string>("Razonsocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdFactura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.FamiliadeProducto", b =>
                {
                    b.Property<int>("IdFamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFamilia"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFamilia");

                    b.ToTable("FamiliadeProductos");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Intentos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFamilia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdFamilia");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.DetalleFactura", b =>
                {
                    b.HasOne("DatosPruebaTecnica.Models.Factura", "Factura")
                        .WithMany("DetalleFactura")
                        .HasForeignKey("IdFactura");

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.Producto", b =>
                {
                    b.HasOne("DatosPruebaTecnica.Models.FamiliadeProducto", "FamiliadeProducto")
                        .WithMany("Productos")
                        .HasForeignKey("IdFamilia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamiliadeProducto");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.Factura", b =>
                {
                    b.Navigation("DetalleFactura");
                });

            modelBuilder.Entity("DatosPruebaTecnica.Models.FamiliadeProducto", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
