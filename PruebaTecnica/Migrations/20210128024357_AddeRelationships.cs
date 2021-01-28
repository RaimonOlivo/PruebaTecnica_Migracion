using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.Migrations
{
    public partial class AddeRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Solicitud",
                newName: "Personaid");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Solicitud",
                newName: "Estadoid");

            migrationBuilder.AlterColumn<int>(
                name: "Personaid",
                table: "Solicitud",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Estadoid",
                table: "Solicitud",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_Estadoid",
                table: "Solicitud",
                column: "Estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_Personaid",
                table: "Solicitud",
                column: "Personaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Estados_Estadoid",
                table: "Solicitud",
                column: "Estadoid",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_Personas_Personaid",
                table: "Solicitud",
                column: "Personaid",
                principalTable: "Personas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Estados_Estadoid",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_Personas_Personaid",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_Estadoid",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_Personaid",
                table: "Solicitud");

            migrationBuilder.RenameColumn(
                name: "Personaid",
                table: "Solicitud",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "Estadoid",
                table: "Solicitud",
                newName: "EstadoId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Solicitud",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoId",
                table: "Solicitud",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
