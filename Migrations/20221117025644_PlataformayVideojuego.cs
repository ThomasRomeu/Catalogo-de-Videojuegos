using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primerParcial.Migrations
{
    public partial class PlataformayVideojuego : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Videojuegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFundada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

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
    }
}
