using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    idPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    apellido = table.Column<string>(nullable: true),
                    cedula = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    grupoSanguineo = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.idPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    apellido = table.Column<string>(nullable: true),
                    contraseña = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    especialidad = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    idDiagnostico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentario = table.Column<string>(nullable: true),
                    enfermedad = table.Column<string>(nullable: true),
                    especialidad = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    idDoctor = table.Column<int>(nullable: false),
                    idPaciente = table.Column<int>(nullable: false),
                    sintomas = table.Column<string>(nullable: true),
                    usuarioidUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.idDiagnostico);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Usuario_usuarioidUsuario",
                        column: x => x.usuarioidUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_idPaciente",
                table: "Diagnostico",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_usuarioidUsuario",
                table: "Diagnostico",
                column: "usuarioidUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
