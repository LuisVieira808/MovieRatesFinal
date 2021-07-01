using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class FilmesFavoritosFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadorIdUtilizador",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_UtilizadorIdUtilizador",
                table: "Favoritos");

            migrationBuilder.DropColumn(
                name: "UtilizadorIdUtilizador",
                table: "Favoritos");

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

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UtilizadoresFK",
                table: "Favoritos",
                column: "UtilizadoresFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadoresFK",
                table: "Favoritos",
                column: "UtilizadoresFK",
                principalTable: "Utilizadores",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadoresFK",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_UtilizadoresFK",
                table: "Favoritos");

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorIdUtilizador",
                table: "Favoritos",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UtilizadorIdUtilizador",
                table: "Favoritos",
                column: "UtilizadorIdUtilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Utilizadores_UtilizadorIdUtilizador",
                table: "Favoritos",
                column: "UtilizadorIdUtilizador",
                principalTable: "Utilizadores",
                principalColumn: "IdUtilizador",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
