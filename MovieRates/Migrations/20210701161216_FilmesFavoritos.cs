using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmesFavoritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ControlarReview",
                table: "Utilizadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdFavoritos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadoresFK = table.Column<int>(type: "int", nullable: false),
                    UtilizadorIdCategorias = table.Column<int>(type: "int", nullable: true),
                    FilmesFK = table.Column<int>(type: "int", nullable: false),
                    UtilizadoresIdUtilizador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavoritos);
                    table.ForeignKey(
                        name: "FK_Favoritos_Categorias_UtilizadorIdCategorias",
                        column: x => x.UtilizadorIdCategorias,
                        principalTable: "Categorias",
                        principalColumn: "IdCategorias",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favoritos_Filmes_FilmesFK",
                        column: x => x.FilmesFK,
                        principalTable: "Filmes",
                        principalColumn: "IdFilmes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Utilizadores_UtilizadoresIdUtilizador",
                        column: x => x.UtilizadoresIdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "1fdb700a-b8e1-4ab7-849e-555d47cf2d97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "fd1de775-ebbb-4f1f-af5f-a7b171a70168");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_FilmesFK",
                table: "Favoritos",
                column: "FilmesFK");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UtilizadoresIdUtilizador",
                table: "Favoritos",
                column: "UtilizadoresIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UtilizadorIdCategorias",
                table: "Favoritos",
                column: "UtilizadorIdCategorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropColumn(
                name: "ControlarReview",
                table: "Utilizadores");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "91bd6abd-3357-4b12-89a4-6e0b8cab9bb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "cc831734-7a3c-4c40-863f-4b144d2e10f5");
        }
    }
}
