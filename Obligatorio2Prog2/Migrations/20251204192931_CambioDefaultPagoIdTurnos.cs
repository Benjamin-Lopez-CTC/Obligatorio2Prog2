using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2Prog2.Migrations
{
    /// <inheritdoc />
    public partial class CambioDefaultPagoIdTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pagos_PagoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_PagoId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "PagoId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PagoId",
                table: "Turnos",
                column: "PagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pagos_PagoId",
                table: "Turnos",
                column: "PagoId",
                principalTable: "Pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(
                "UPDATE Turnos SET PagoId = 0 WHERE PagoId IS NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pagos_PagoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_PagoId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "PagoId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PagoId",
                table: "Turnos",
                column: "PagoId",
                unique: true,
                filter: "[PagoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pagos_PagoId",
                table: "Turnos",
                column: "PagoId",
                principalTable: "Pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
