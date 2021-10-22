using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Lavoro.Migrations
{
    public partial class Inizio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reparti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dipendenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cognome = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    Stipendio = table.Column<double>(type: "double", nullable: false),
                    RepartoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dipendenti_Reparti_RepartoId",
                        column: x => x.RepartoId,
                        principalTable: "Reparti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dirigenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cognome = table.Column<string>(type: "text", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    Stipendio = table.Column<double>(type: "double", nullable: false),
                    RepartoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirigenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dirigenti_Reparti_RepartoId",
                        column: x => x.RepartoId,
                        principalTable: "Reparti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_RepartoId",
                table: "Dipendenti",
                column: "RepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dirigenti_RepartoId",
                table: "Dirigenti",
                column: "RepartoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dipendenti");

            migrationBuilder.DropTable(
                name: "Dirigenti");

            migrationBuilder.DropTable(
                name: "Reparti");
        }
    }
}
