using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPruebatecnica.Migrations
{
    /// <inheritdoc />
    public partial class eliminadotablaIntentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntentosUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Logins",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intentos",
                table: "Logins",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "Intentos",
                table: "Logins");

            migrationBuilder.CreateTable(
                name: "IntentosUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogin = table.Column<int>(type: "int", nullable: false),
                    Intentos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntentosUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntentosUsers_Logins_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntentosUsers_IdLogin",
                table: "IntentosUsers",
                column: "IdLogin");
        }
    }
}
