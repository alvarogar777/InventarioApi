using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventarioAPI.Migrations
{
    public partial class categoria_tipoEmpaque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodigoCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodigoCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Nit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dpi = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Pagina_Web = table.Column<string>(nullable: true),
                    ContactoPrincipal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.CodigoProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpaques",
                columns: table => new
                {
                    CodigoEmpaque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpaques", x => x.CodigoEmpaque);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Emailclientes",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: false),
                    ClienteNit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emailclientes", x => x.Nit);
                    table.ForeignKey(
                        name: "FK_Emailclientes_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Numerofactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClienteNit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Numerofactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoClientes",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: true),
                    ClienteNit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoClientes", x => x.CodigoTelefono);
                    table.ForeignKey(
                        name: "FK_TelefonoClientes_Clientes_ClienteNit",
                        column: x => x.ClienteNit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_CodigoProveedor",
                        column: x => x.CodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailProveedor",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProveedorCodigoProveedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailProveedor", x => x.CodigoProveedor);
                    table.ForeignKey(
                        name: "FK_EmailProveedor_Proveedores_ProveedorCodigoProveedor",
                        column: x => x.ProveedorCodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoProveedores",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProveedoresCodigoProveedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoProveedores", x => x.CodigoProveedor);
                    table.ForeignKey(
                        name: "FK_TelefonoProveedores_Proveedores_ProveedoresCodigoProveedor",
                        column: x => x.ProveedoresCodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    CodigoEmpaque = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "Categorias",
                        principalColumn: "CodigoCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TipoEmpaques_CodigoEmpaque",
                        column: x => x.CodigoEmpaque,
                        principalTable: "TipoEmpaques",
                        principalColumn: "CodigoEmpaque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID1",
                        column: x => x.RoleID1,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false),
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    CompraIdCompra = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Compras_CompraIdCompra",
                        column: x => x.CompraIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    CodigoDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroFactura = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descuento = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.CodigoDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_NumeroFactura",
                        column: x => x.NumeroFactura,
                        principalTable: "Facturas",
                        principalColumn: "Numerofactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    CodigoInventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoRegistro = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Entradas = table.Column<int>(nullable: false),
                    Salidas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.CodigoInventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CodigoProveedor",
                table: "Compras",
                column: "CodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CodigoProducto",
                table: "DetalleCompras",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraIdCompra",
                table: "DetalleCompras",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_CodigoProducto",
                table: "DetalleFacturas",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_NumeroFactura",
                table: "DetalleFacturas",
                column: "NumeroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Emailclientes_ClienteNit",
                table: "Emailclientes",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_EmailProveedor_ProveedorCodigoProveedor",
                table: "EmailProveedor",
                column: "ProveedorCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteNit",
                table: "Facturas",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_CodigoProducto",
                table: "Inventarios",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoCategoria",
                table: "Productos",
                column: "CodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoEmpaque",
                table: "Productos",
                column: "CodigoEmpaque");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoClientes_ClienteNit",
                table: "TelefonoClientes",
                column: "ClienteNit");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoProveedores_ProveedoresCodigoProveedor",
                table: "TelefonoProveedores",
                column: "ProveedoresCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID1",
                table: "UserRoles",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Emailclientes");

            migrationBuilder.DropTable(
                name: "EmailProveedor");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "TelefonoClientes");

            migrationBuilder.DropTable(
                name: "TelefonoProveedores");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "TipoEmpaques");
        }
    }
}
