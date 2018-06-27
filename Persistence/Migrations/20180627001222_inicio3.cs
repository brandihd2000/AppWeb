using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class inicio3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Usuario_usuarioidUsuario",
                table: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostico_usuarioidUsuario",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "usuarioidUsuario",
                table: "Diagnostico");

            migrationBuilder.RenameColumn(
                name: "idDoctor",
                table: "Diagnostico",
                newName: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_idUsuario",
                table: "Diagnostico",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Usuario_idUsuario",
                table: "Diagnostico",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Usuario_idUsuario",
                table: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostico_idUsuario",
                table: "Diagnostico");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Diagnostico",
                newName: "idDoctor");

            migrationBuilder.AddColumn<int>(
                name: "usuarioidUsuario",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_usuarioidUsuario",
                table: "Diagnostico",
                column: "usuarioidUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Usuario_usuarioidUsuario",
                table: "Diagnostico",
                column: "usuarioidUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
