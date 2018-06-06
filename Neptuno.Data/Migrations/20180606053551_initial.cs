using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptuno.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    NombreCategoria = table.Column<string>(maxLength: 15, nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    IdCliente = table.Column<string>(maxLength: 5, nullable: false),
                    NombreCompania = table.Column<string>(maxLength: 40, nullable: false),
                    NombreContacto = table.Column<string>(maxLength: 30, nullable: true),
                    CargoContacto = table.Column<string>(maxLength: 30, nullable: true),
                    Direccion = table.Column<string>(maxLength: 60, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    CodPostal = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 15, nullable: true),
                    Telefono = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "CompaniaEnvio",
                columns: table => new
                {
                    IdCompaniaEnvio = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    NombreCompania = table.Column<string>(maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniaEnvio", x => x.IdCompaniaEnvio);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    Apellidos = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false),
                    Cargo = table.Column<string>(maxLength: 30, nullable: true),
                    Tratamiento = table.Column<string>(maxLength: 25, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Direccion = table.Column<string>(maxLength: 60, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    CodPostal = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 15, nullable: true),
                    TelDomicilio = table.Column<string>(maxLength: 24, nullable: true),
                    Extension = table.Column<string>(maxLength: 4, nullable: true),
                    Foto = table.Column<string>(maxLength: 255, nullable: true),
                    Notas = table.Column<string>(nullable: true),
                    Jefe = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    NombreCompania = table.Column<string>(maxLength: 40, nullable: false),
                    NombreContacto = table.Column<string>(maxLength: 30, nullable: true),
                    CargoContacto = table.Column<string>(maxLength: 30, nullable: true),
                    Direccion = table.Column<string>(maxLength: 60, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    CodPostal = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 15, nullable: true),
                    Telefono = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    PaginaPrincipal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    IdCliente = table.Column<string>(maxLength: 5, nullable: false),
                    IdEmpleado = table.Column<int>(nullable: true),
                    FechaPedido = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaEnvio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FormaEnvio = table.Column<int>(nullable: true),
                    Cargo = table.Column<decimal>(type: "money", nullable: true),
                    Destinatario = table.Column<string>(maxLength: 40, nullable: true),
                    DireccionDestinatario = table.Column<string>(maxLength: 60, nullable: true),
                    CiudadDestinatario = table.Column<string>(maxLength: 15, nullable: true),
                    RegionDestinatario = table.Column<string>(maxLength: 15, nullable: true),
                    CodPostalDestinatario = table.Column<string>(maxLength: 10, nullable: true),
                    PaisDestinatario = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_CompaniaEnvio",
                        column: x => x.FormaEnvio,
                        principalTable: "CompaniaEnvio",
                        principalColumn: "IdCompaniaEnvio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Empleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    NombreProducto = table.Column<string>(maxLength: 40, nullable: false),
                    IdProveedor = table.Column<int>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: true),
                    CantidadPorUnidad = table.Column<string>(maxLength: 20, nullable: true),
                    PrecioUnidad = table.Column<decimal>(type: "money", nullable: true),
                    UnidadesEnExistencia = table.Column<short>(nullable: true),
                    UnidadesEnPedido = table.Column<short>(nullable: true),
                    NivelNuevoPedido = table.Column<int>(nullable: true),
                    Suspendido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaPedido",
                columns: table => new
                {
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    IdPedido = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    PrecioUnidad = table.Column<decimal>(type: "money", nullable: false),
                    Cantidad = table.Column<short>(nullable: false),
                    Descuento = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaPedido", x => new { x.IdPedido, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_LineaPedido_Pedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineaPedido_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineaPedido_IdProducto",
                table: "LineaPedido",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_FormaEnvio",
                table: "Pedido",
                column: "FormaEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEmpleado",
                table: "Pedido",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProveedor",
                table: "Producto",
                column: "IdProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "CompaniaEnvio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
