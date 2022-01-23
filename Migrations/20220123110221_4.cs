using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AanmeldForm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoorNaam = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: true),
                    Geboortedatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Aandoening = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Orthopedagoog = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AanmeldForm", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AanmeldForm");
        }
    }
}
