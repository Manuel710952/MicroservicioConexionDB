using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class MigracionSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutorLibroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    AutorLibroGuid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => x.AutorLibroId);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademico",
                columns: table => new
                {
                    GradoAcademicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    CentroAcademico = table.Column<string>(nullable: false),
                    FechaGrado = table.Column<DateTime>(nullable: true),
                    AutorLibroId = table.Column<int>(nullable: false),
                    GradoAcademicoGuid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademico", x => x.GradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_GradoAcademico_AutorLibro_AutorLibroId",
                        column: x => x.AutorLibroId,
                        principalTable: "AutorLibro",
                        principalColumn: "AutorLibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademico_AutorLibroId",
                table: "GradoAcademico",
                column: "AutorLibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademico");

            migrationBuilder.DropTable(
                name: "AutorLibro");
        }
    }
}
