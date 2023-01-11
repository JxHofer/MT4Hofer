using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MT4Hofer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schulklassen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErstelltDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schulklassen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schueler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchulklasseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schueler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schueler_Schulklassen_SchulklasseId",
                        column: x => x.SchulklasseId,
                        principalTable: "Schulklassen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klassenbucheintraege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchuelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klassenbucheintraege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klassenbucheintraege_Schueler_SchuelerId",
                        column: x => x.SchuelerId,
                        principalTable: "Schueler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klassenbucheintraege_SchuelerId",
                table: "Klassenbucheintraege",
                column: "SchuelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Schueler_SchulklasseId",
                table: "Schueler",
                column: "SchulklasseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klassenbucheintraege");

            migrationBuilder.DropTable(
                name: "Schueler");

            migrationBuilder.DropTable(
                name: "Schulklassen");
        }
    }
}
