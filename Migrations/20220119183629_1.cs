using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hulpverlener",
                columns: table => new
                {
                    Hulpverlenerid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoorNaam = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: true),
                    Specialisme = table.Column<string>(type: "TEXT", nullable: true),
                    Gebruikersnaam = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "TEXT", nullable: true),
                    ProfielFoto = table.Column<string>(type: "TEXT", nullable: true),
                    WiebenIk = table.Column<string>(type: "TEXT", nullable: true),
                    MijnSTudie = table.Column<string>(type: "TEXT", nullable: true),
                    WatAls = table.Column<string>(type: "TEXT", nullable: true),
                    HoeHelpen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hulpverlener", x => x.Hulpverlenerid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hulpverlener");
        }
    }
}
