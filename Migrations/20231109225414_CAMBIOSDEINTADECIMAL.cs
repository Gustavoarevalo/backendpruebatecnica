using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPruebatecnica.Migrations
{
    /// <inheritdoc />
    public partial class CAMBIOSDEINTADECIMAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Facturas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "Facturas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "IGV",
                table: "Facturas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "DetalleFacturas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "DetalleFacturas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Facturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Subtotal",
                table: "Facturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "IGV",
                table: "Facturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Subtotal",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                table: "DetalleFacturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_Facturas_IdFactura",
                table: "DetalleFacturas",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura");
        }
    }
}
