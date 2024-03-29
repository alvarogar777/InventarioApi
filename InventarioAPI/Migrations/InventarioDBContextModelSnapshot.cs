﻿// <auto-generated />
using System;
using InventarioAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventarioAPI.Migrations
{
    [DbContext(typeof(InventarioDBContext))]
    partial class InventarioDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventarioAPI.Entities.Categoria", b =>
                {
                    b.Property<int>("CodigoCategoria")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Cliente", b =>
                {
                    b.Property<string>("Nit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<string>("Dpi");

                    b.Property<string>("Nombre");

                    b.HasKey("Nit");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<int>("NumeroDocumento");

                    b.Property<decimal>("Total");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("IdCompra");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleCompra", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoProducto");

                    b.Property<int>("IdCompra");

                    b.Property<decimal>("Precio");

                    b.HasKey("IdDetalle");

                    b.HasIndex("CodigoProducto");

                    b.HasIndex("IdCompra");

                    b.ToTable("DetalleCompras");
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleFactura", b =>
                {
                    b.Property<int>("CodigoDetalle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoProducto");

                    b.Property<decimal>("Descuento");

                    b.Property<int>("NumeroFactura");

                    b.Property<decimal>("Precio");

                    b.HasKey("CodigoDetalle");

                    b.HasIndex("CodigoProducto");

                    b.HasIndex("NumeroFactura");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Emailcliente", b =>
                {
                    b.Property<int>("CodigoEmail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nit");

                    b.Property<string>("email");

                    b.HasKey("CodigoEmail");

                    b.HasIndex("Nit");

                    b.ToTable("Emailclientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailProveedor", b =>
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

            modelBuilder.Entity("InventarioAPI.Entities.Factura", b =>
                {
                    b.Property<int>("Numerofactura")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nit");

                    b.Property<decimal>("Total");

                    b.HasKey("Numerofactura");

                    b.HasIndex("Nit");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Inventario", b =>
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

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Producto", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCategoria");

                    b.Property<int>("CodigoEmpaque");

                    b.Property<string>("Descripcion");

                    b.Property<int>("Existencia");

                    b.Property<string>("Imagen");

                    b.Property<decimal>("PrecioPorDocena");

                    b.Property<decimal>("PrecioPorMayor");

                    b.Property<decimal>("PrecioUnitario");

                    b.HasKey("CodigoProducto");

                    b.HasIndex("CodigoCategoria");

                    b.HasIndex("CodigoEmpaque");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Proveedor", b =>
                {
                    b.Property<int>("CodigoProveedor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactoPrincipal");

                    b.Property<string>("Direccion");

                    b.Property<string>("Nit");

                    b.Property<string>("Pagina_Web");

                    b.Property<string>("RazonSocial");

                    b.HasKey("CodigoProveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoCliente", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nit");

                    b.Property<string>("Numero");

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("Nit");

                    b.ToTable("TelefonoClientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoProveedor", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Numero");

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("TelefonoProveedores");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TipoEmpaque", b =>
                {
                    b.Property<int>("CodigoEmpaque")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoEmpaque");

                    b.ToTable("TipoEmpaques");
                });

            modelBuilder.Entity("InventarioAPI.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<bool>("Enabled");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InventarioAPI.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoleID1");

                    b.Property<int>("UserID");

                    b.HasKey("RoleID");

                    b.HasIndex("RoleID1");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Compra", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleCompra", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.Compra", "Compra")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleFactura", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("NumeroFactura")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Emailcliente", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("Emailclientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailProveedor", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedor")
                        .WithMany("EmailProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Factura", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Inventario", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("Inventarios")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Producto", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.TipoEmpaque", "TipoEmpaque")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoEmpaque")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoCliente", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("TelefonoClientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoProveedor", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedores")
                        .WithMany("TelefonoProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.UserRole", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID1");

                    b.HasOne("InventarioAPI.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
