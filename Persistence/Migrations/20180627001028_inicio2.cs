using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    idObservaciones = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idPaciente = table.Column<int>(nullable: false),
                    discapacidad = table.Column<string>(nullable: true),
                    enfermedades = table.Column<string>(nullable: true),
                    alergias = table.Column<string>(nullable: true),
                    medicamentos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.idObservaciones);
                    table.ForeignKey(
                        name: "FK_Observaciones_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    idTratamiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idDiagnostico = table.Column<int>(nullable: false),
                    fechaInicio = table.Column<DateTime>(nullable: false),
                    fechaFin = table.Column<DateTime>(nullable: false),
                    comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.idTratamiento);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Diagnostico_idDiagnostico",
                        column: x => x.idDiagnostico,
                        principalTable: "Diagnostico",
                        principalColumn: "idDiagnostico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_idPaciente",
                table: "Observaciones",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_idDiagnostico",
                table: "Tratamiento",
                column: "idDiagnostico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "Tratamiento");
        }
    }
}
