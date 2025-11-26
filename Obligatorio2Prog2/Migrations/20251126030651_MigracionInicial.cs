using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2Prog2.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EspecialidadM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MatriculaM = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NombreUsuarioM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContraseniaM = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreP = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumDocumentoP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacP = table.Column<DateOnly>(type: "date", nullable: false),
                    TelefonoP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObraSocialP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreUsuarioP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContraseniaP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: false),
                    MontoPago = table.Column<int>(type: "int", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionistas",
                columns: table => new
                {
                    RecepcionistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ApellidoR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NumDocumentoR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuarioR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContraseniaR = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionistas", x => x.RecepcionistaId);
                });

            migrationBuilder.CreateTable(
                name: "Horas",
                columns: table => new
                {
                    HoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraTurno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.HoraId);
                    table.ForeignKey(
                        name: "FK_Horas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    FechaTurno = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    HoraId = table.Column<int>(type: "int", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                    table.ForeignKey(
                        name: "FK_Turnos_Horas_HoraId",
                        column: x => x.HoraId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId");
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horas_MedicoId",
                table: "Horas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_MatriculaM",
                table: "Medicos",
                column: "MatriculaM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_HoraId",
                table: "Turnos",
                column: "HoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PagoId",
                table: "Turnos",
                column: "PagoId",
                unique: true,
                filter: "[PagoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recepcionistas");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Horas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
