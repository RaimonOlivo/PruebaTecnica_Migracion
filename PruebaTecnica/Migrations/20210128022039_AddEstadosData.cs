using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.Migrations
{
    public partial class AddEstadosData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "id", "estado" },
                values: new object[] { 1, "Abiertas" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "id", "estado" },
                values: new object[] { 2, "Aprobadas" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "id", "estado" },
                values: new object[] { 3, "Canceladas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
