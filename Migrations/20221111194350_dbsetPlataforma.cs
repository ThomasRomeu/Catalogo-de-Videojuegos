using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class dbsetPlataforma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videojuegos_Plataforma_PlataformaId",
                table: "Videojuegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plataforma",
                table: "Plataforma");

            migrationBuilder.RenameTable(
                name: "Plataforma",
                newName: "Plataformas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plataformas",
                table: "Plataformas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videojuegos_Plataformas_PlataformaId",
                table: "Videojuegos",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videojuegos_Plataformas_PlataformaId",
                table: "Videojuegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plataformas",
                table: "Plataformas");

            migrationBuilder.RenameTable(
                name: "Plataformas",
                newName: "Plataforma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plataforma",
                table: "Plataforma",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videojuegos_Plataforma_PlataformaId",
                table: "Videojuegos",
                column: "PlataformaId",
                principalTable: "Plataforma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
