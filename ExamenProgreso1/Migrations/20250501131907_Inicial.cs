using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razon = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NombreVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dueno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dueno_Cita_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cumple = table.Column<DateTime>(type: "datetime2", nullable: false),
                    aspecto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    pablomontalvo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuenoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Dueno_DuenoId",
                        column: x => x.DuenoId,
                        principalTable: "Dueno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dueno_CitaId",
                table: "Dueno",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_DuenoId",
                table: "Mascota",
                column: "DuenoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Dueno");

            migrationBuilder.DropTable(
                name: "Cita");
        }
    }
}
