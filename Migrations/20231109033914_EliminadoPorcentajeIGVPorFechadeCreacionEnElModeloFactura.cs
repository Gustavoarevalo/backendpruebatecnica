using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPruebatecnica.Migrations
{
    /// <inheritdoc />
    public partial class EliminadoPorcentajeIGVPorFechadeCreacionEnElModeloFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Porcentaje_de_IGV",
                table: "Facturas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Subtotal",
                table: "DetalleFacturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "Porcentaje_de_IGV",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Subtotal",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
