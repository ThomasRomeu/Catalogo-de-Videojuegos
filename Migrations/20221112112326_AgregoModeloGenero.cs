using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class AgregoModeloGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Videojuegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroVideojuego",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    VideojuegosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroVideojuego", x => new { x.GenerosId, x.VideojuegosId });
                    table.ForeignKey(
                        name: "FK_GeneroVideojuego_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroVideojuego_Videojuegos_VideojuegosId",
                        column: x => x.VideojuegosId,
                        principalTable: "Videojuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroVideojuego_VideojuegosId",
                table: "GeneroVideojuego",
                column: "VideojuegosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroVideojuego");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Videojuegos");
        }
    }
}
