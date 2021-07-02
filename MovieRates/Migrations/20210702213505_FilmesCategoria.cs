using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmesCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "FilmeCategorias",
                columns: new[] { "IdFilmeCategorias", "CategoriasFK", "FilmesFK" },
                values: new object[,]
                {
                    { 40, 20, 1 },
                    { 39, 19, 2 },
                    { 38, 18, 3 },
                    { 37, 17, 4 },
                    { 36, 16, 5 },
                    { 35, 15, 6 },
                    { 34, 14, 7 },
                    { 33, 13, 8 },
                    { 32, 12, 9 },
                    { 31, 11, 10 },
                    { 29, 9, 12 },
                    { 28, 8, 13 },
                    { 27, 7, 14 },
                    { 26, 6, 15 },
                    { 25, 5, 16 },
                    { 24, 4, 17 },
                    { 23, 3, 18 },
                    { 22, 2, 19 },
                    { 30, 10, 11 },
                    { 21, 1, 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FilmeCategorias",
                keyColumn: "IdFilmeCategorias",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "fe45e94e-3186-4ea4-9798-b460d6db537e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "858632c5-5d5f-4635-b889-6d0438be760d");
        }
    }
}
