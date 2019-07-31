﻿// <auto-generated />
using System;
using Inventario2019.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventario2019.Migrations
{
    [DbContext(typeof(InventarioDBContext))]
    [Migration("20190727062933_Producto")]
    partial class Producto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inventario2019.Entities.Categoria", b =>
                {
                    b.Property<int>("CodigoCategoria")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Inventario2019.Entities.Cliente", b =>
                {
                    b.Property<string>("Nit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<string>("Dpi");

                    b.Property<string>("Nombre");

                    b.HasKey("Nit");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Inventario2019.Entities.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("NumeroDocumento");

                    b.Property<decimal>("Total");

                    b.HasKey("IdCompra");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Inventario2019.Entities.DetalleCompra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoProducto");

                    b.Property<int?>("CompraIdCompra");

                    b.Property<int>("IdDetalle");

                    b.Property<decimal>("Precio");

                    b.HasKey("IdCompra");

                    b.HasIndex("CodigoProducto");

                    b.HasIndex("CompraIdCompra");

                    b.ToTable("DetalleCompra");
                });

            modelBuilder.Entity("Inventario2019.Entities.DetalleFactura", b =>
                {
                    b.Property<int>("CodigoDetalle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoFactura");

                    b.Property<decimal>("Descuento");

                    b.Property<int>("NumeroFactura");

                    b.Property<decimal>("Precio");

                    b.Property<int?>("ProductoCodigoProducto");

                    b.HasKey("CodigoDetalle");

                    b.HasIndex("NumeroFactura");

                    b.HasIndex("ProductoCodigoProducto");

                    b.ToTable("DetalleFactura");
                });

            modelBuilder.Entity("Inventario2019.Entities.EmailCliente", b =>
                {
                    b.Property<int>("CodigoEmail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Nit");

                    b.HasKey("CodigoEmail");

                    b.HasIndex("Nit");

                    b.ToTable("EmailCliente");
                });

            modelBuilder.Entity("Inventario2019.Entities.EmailProveedor", b =>
                {
                    b.Property<int>("CodigoEmail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<string>("Email");

                    b.HasKey("CodigoEmail");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("EmailProveedor");
                });

            modelBuilder.Entity("Inventario2019.Entities.Factura", b =>
                {
                    b.Property<int>("NumeroFactura")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nit");

                    b.Property<decimal>("Total");

                    b.HasKey("NumeroFactura");

                    b.HasIndex("Nit");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Inventario2019.Entities.Inventario", b =>
                {
                    b.Property<int>("CodigoInventario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProducto");

                    b.Property<int>("Entradas");

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Precio");

                    b.Property<int>("Salidas");

                    b.Property<string>("TipoRegistro");

                    b.HasKey("CodigoInventario");

                    b.HasIndex("CodigoProducto");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("Inventario2019.Entities.Producto", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCategoria");

                    b.Property<int>("CodigoEmpaque");

                    b.Property<string>("Descripcion");

                    b.Property<int>("Exixtencia");

                    b.Property<string>("Imagen");

                    b.Property<decimal>("PrecioPorDocena");

                    b.Property<decimal>("PrecioPorMayor");

                    b.Property<decimal>("PrecioUnitario");

                    b.HasKey("CodigoProducto");

                    b.HasIndex("CodigoCategoria");

                    b.HasIndex("CodigoEmpaque");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Inventario2019.Entities.Proveedor", b =>
                {
                    b.Property<int>("CodigoProveedor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactoPrincipal");

                    b.Property<string>("Direccion");

                    b.Property<string>("Nit");

                    b.Property<string>("PaginaWeb");

                    b.Property<string>("RazonSocial");

                    b.HasKey("CodigoProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("Inventario2019.Entities.TelefonoCliente", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nit");

                    b.Property<string>("Numero");

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("Nit");

                    b.ToTable("TelefonoCliente");
                });

            modelBuilder.Entity("Inventario2019.Entities.TelefonoProveedor", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Numero");

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("TelefonoProveedor");
                });

            modelBuilder.Entity("Inventario2019.Entities.TipoEmpaque", b =>
                {
                    b.Property<int>("CodigoEmpaque")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoEmpaque");

                    b.ToTable("TipoEmpaque");
                });

            modelBuilder.Entity("Inventario2019.Entities.Compra", b =>
                {
                    b.HasOne("Inventario2019.Entities.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inventario2019.Entities.DetalleCompra", b =>
                {
                    b.HasOne("Inventario2019.Entities.Producto", "Producto")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inventario2019.Entities.Compra", "Compra")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("CompraIdCompra");
                });

            modelBuilder.Entity("Inventario2019.Entities.DetalleFactura", b =>
                {
                    b.HasOne("Inventario2019.Entities.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("NumeroFactura")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inventario2019.Entities.Producto", "Producto")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("ProductoCodigoProducto");
                });

            modelBuilder.Entity("Inventario2019.Entities.EmailCliente", b =>
                {
                    b.HasOne("Inventario2019.Entities.Cliente", "Cliente")
                        .WithMany("EmailClientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("Inventario2019.Entities.EmailProveedor", b =>
                {
                    b.HasOne("Inventario2019.Entities.Proveedor", "Proveedor")
                        .WithMany("EmailProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inventario2019.Entities.Factura", b =>
                {
                    b.HasOne("Inventario2019.Entities.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("Inventario2019.Entities.Inventario", b =>
                {
                    b.HasOne("Inventario2019.Entities.Producto", "Producto")
                        .WithMany("Inventarios")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inventario2019.Entities.Producto", b =>
                {
                    b.HasOne("Inventario2019.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inventario2019.Entities.TipoEmpaque", "TipoEmpaque")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoEmpaque")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inventario2019.Entities.TelefonoCliente", b =>
                {
                    b.HasOne("Inventario2019.Entities.Cliente", "Cliente")
                        .WithMany("TelefonoClientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("Inventario2019.Entities.TelefonoProveedor", b =>
                {
                    b.HasOne("Inventario2019.Entities.Proveedor", "Proveedor")
                        .WithMany("TelefonosProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
