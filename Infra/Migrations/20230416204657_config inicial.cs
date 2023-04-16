using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class configinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sgps");

            migrationBuilder.CreateTable(
                name: "Consulta",
                schema: "sgps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestadorId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                schema: "sgps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                schema: "sgps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoExameId = table.Column<long>(type: "bigint", nullable: false),
                    ConveniadoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_TipoExame_TipoExameId",
                        column: x => x.TipoExameId,
                        principalSchema: "sgps",
                        principalTable: "TipoExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exame_TipoExameId",
                schema: "sgps",
                table: "Exame",
                column: "TipoExameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta",
                schema: "sgps");

            migrationBuilder.DropTable(
                name: "Exame",
                schema: "sgps");

            migrationBuilder.DropTable(
                name: "TipoExame",
                schema: "sgps");
        }
    }
}
