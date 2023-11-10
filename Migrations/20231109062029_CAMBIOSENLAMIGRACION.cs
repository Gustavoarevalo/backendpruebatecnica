using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPruebatecnica.Migrations
{
    /// <inheritdoc />
    public partial class CAMBIOSENLAMIGRACION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.DropColumn(
                name: "CodigoProducto",
                table: "DetalleFacturas");

            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "DetalleFacturas");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "DetalleFacturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                table: "DetalleFacturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "DetalleFacturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "DetalleFacturas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "DetalleFacturas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "DetalleFacturas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "DetalleFacturas");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoProducto",
                table: "DetalleFacturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "DetalleFacturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
