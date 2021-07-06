using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmeListaDeCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeCategorias");

            migrationBuilder.CreateTable(
                name: "CategoriasFilmes",
                columns: table => new
                {
                    ListaDeCategoriasIdCategorias = table.Column<int>(type: "int", nullable: false),
                    ListaDeFilmesIdFilmes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasFilmes", x => new { x.ListaDeCategoriasIdCategorias, x.ListaDeFilmesIdFilmes });
                    table.ForeignKey(
                        name: "FK_CategoriasFilmes_Categorias_ListaDeCategoriasIdCategorias",
                        column: x => x.ListaDeCategoriasIdCategorias,
                        principalTable: "Categorias",
                        principalColumn: "IdCategorias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriasFilmes_Filmes_ListaDeFilmesIdFilmes",
                        column: x => x.ListaDeFilmesIdFilmes,
                        principalTable: "Filmes",
                        principalColumn: "IdFilmes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "9e0be78d-c50d-473f-b8dc-3b275ddcf7cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "4f7f4f0a-ef24-4dcf-bc3d-eb166c0f66b0");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasFilmes_ListaDeFilmesIdFilmes",
                table: "CategoriasFilmes",
                column: "ListaDeFilmesIdFilmes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasFilmes");

            migrationBuilder.CreateTable(
                name: "FilmeCategorias",
                columns: table => new
                {
                    IdFilmeCategorias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriasFK = table.Column<int>(type: "int", nullable: false),
                    FilmesFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeCategorias", x => x.IdFilmeCategorias);
                    table.ForeignKey(
                        name: "FK_FilmeCategorias_Categorias_CategoriasFK",
                        column: x => x.CategoriasFK,
                        principalTable: "Categorias",
                        principalColumn: "IdCategorias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeCategorias_Filmes_FilmesFK",
                        column: x => x.FilmesFK,
                        principalTable: "Filmes",
                        principalColumn: "IdFilmes",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "FilmeCategorias",
                columns: new[] { "IdFilmeCategorias", "CategoriasFK", "FilmesFK" },
                values: new object[,]
                {
                    { 39, 19, 2 },
                    { 23, 3, 18 },
                    { 24, 4, 17 },
                    { 25, 5, 16 },
                    { 26, 6, 15 },
                    { 27, 7, 14 },
                    { 28, 8, 13 },
                    { 29, 9, 12 },
                    { 40, 20, 1 },
                    { 30, 10, 11 },
                    { 32, 12, 9 },
                    { 33, 13, 8 },
                    { 34, 14, 7 },
                    { 35, 15, 6 },
                    { 36, 16, 5 },
                    { 37, 17, 4 },
                    { 38, 18, 3 },
                    { 22, 2, 19 },
                    { 31, 11, 10 },
                    { 21, 1, 20 },
                    { 19, 19, 19 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 },
                    { 11, 11, 11 },
                    { 12, 12, 12 },
                    { 13, 13, 13 },
                    { 14, 14, 14 },
                    { 15, 15, 15 },
                    { 16, 16, 16 },
                    { 17, 17, 17 },
                    { 18, 18, 18 },
                    { 20, 20, 20 },
                    { 1, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeCategorias_CategoriasFK",
                table: "FilmeCategorias",
                column: "CategoriasFK");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeCategorias_FilmesFK",
                table: "FilmeCategorias",
                column: "FilmesFK");
        }
    }
}
