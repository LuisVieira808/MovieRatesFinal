using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmesFavoritosF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Categorias_UtilizadorIdCategorias",
                table: "Favoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadoresIdUtilizador",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_UtilizadorIdCategorias",
                table: "Favoritos");

            migrationBuilder.DropColumn(
                name: "UtilizadorIdCategorias",
                table: "Favoritos");

            migrationBuilder.RenameColumn(
                name: "UtilizadoresIdUtilizador",
                table: "Favoritos",
                newName: "UtilizadorIdUtilizador");

            migrationBuilder.RenameIndex(
                name: "IX_Favoritos_UtilizadoresIdUtilizador",
                table: "Favoritos",
                newName: "IX_Favoritos_UtilizadorIdUtilizador");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "dbe9c98f-f4e0-45ca-967a-53ce7c42573d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "b114205d-d3d5-4ca7-94dc-2d4c2f44ccf7");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadorIdUtilizador",
                table: "Favoritos",
                column: "UtilizadorIdUtilizador",
                principalTable: "Utilizadores",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadorIdUtilizador",
                table: "Favoritos");

            migrationBuilder.RenameColumn(
                name: "UtilizadorIdUtilizador",
                table: "Favoritos",
                newName: "UtilizadoresIdUtilizador");

            migrationBuilder.RenameIndex(
                name: "IX_Favoritos_UtilizadorIdUtilizador",
                table: "Favoritos",
                newName: "IX_Favoritos_UtilizadoresIdUtilizador");

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorIdCategorias",
                table: "Favoritos",
                type: "int",
                nullable: true);

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
                name: "IX_Favoritos_UtilizadorIdCategorias",
                table: "Favoritos",
                column: "UtilizadorIdCategorias");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Categorias_UtilizadorIdCategorias",
                table: "Favoritos",
                column: "UtilizadorIdCategorias",
                principalTable: "Categorias",
                principalColumn: "IdCategorias",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadoresIdUtilizador",
                table: "Favoritos",
                column: "UtilizadoresIdUtilizador",
                principalTable: "Utilizadores",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
