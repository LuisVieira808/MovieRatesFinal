using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRates.Migrations
{
    public partial class ListaDeCategoriasF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
