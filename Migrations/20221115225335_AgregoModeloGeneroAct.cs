using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class AgregoModeloGeneroAct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Videojuegos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Videojuegos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
