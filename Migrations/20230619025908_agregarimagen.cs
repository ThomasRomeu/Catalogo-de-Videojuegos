using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class agregarimagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RutaFoto",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutaFoto",
                table: "Videojuegos");
        }
    }
}
