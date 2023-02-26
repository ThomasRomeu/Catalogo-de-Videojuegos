using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class RelacionEmpresaVideojuego : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desarrollador",
                table: "Videojuegos");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Videojuegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_EmpresaId",
                table: "Videojuegos",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videojuegos_Empresas_EmpresaId",
                table: "Videojuegos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videojuegos_Empresas_EmpresaId",
                table: "Videojuegos");

            migrationBuilder.DropIndex(
                name: "IX_Videojuegos_EmpresaId",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Videojuegos");

            migrationBuilder.AddColumn<string>(
                name: "Desarrollador",
                table: "Videojuegos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
