using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class TesteCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasFilmes_Categorias_ListaDeCategoriasIdCategorias",
                table: "CategoriasFilmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "ListaDeCategorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListaDeCategorias",
                table: "ListaDeCategorias",
                column: "IdCategorias");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "d4699077-5928-499e-adae-004976eb842f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "84830a49-38d2-43bc-b421-916fe104c4d4");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasFilmes_ListaDeCategorias_ListaDeCategoriasIdCategorias",
                table: "CategoriasFilmes",
                column: "ListaDeCategoriasIdCategorias",
                principalTable: "ListaDeCategorias",
                principalColumn: "IdCategorias",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasFilmes_ListaDeCategorias_ListaDeCategoriasIdCategorias",
                table: "CategoriasFilmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListaDeCategorias",
                table: "ListaDeCategorias");

            migrationBuilder.RenameTable(
                name: "ListaDeCategorias",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "IdCategorias");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "c08bf333-0f5a-4468-bccd-5d0a4e54f831");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "ad29cd54-3954-4289-ad5c-1671c00d6f6b");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasFilmes_Categorias_ListaDeCategoriasIdCategorias",
                table: "CategoriasFilmes",
                column: "ListaDeCategoriasIdCategorias",
                principalTable: "Categorias",
                principalColumn: "IdCategorias",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
