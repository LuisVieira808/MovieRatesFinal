using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmesCategoriaF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "420b2a93-c452-43f3-9c05-3f3746914747");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "cab08425-c44e-4e76-9f54-febf5d2143a8");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategorias",
                keyValue: 3,
                column: "Nome",
                value: "Classic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "46579e71-8e58-46dd-b09e-e682351ccc94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "3f3182f9-f59c-4aa0-9441-11e8ed9d0b49");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategorias",
                keyValue: 3,
                column: "Nome",
                value: "dasfew");
        }
    }
}
