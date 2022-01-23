using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR.Migrations
{
    public partial class addingHulpverlenerToAspNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hulpverlener");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gebruikersnaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoeHelpen",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hulpverlenerid",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MijnSTudie",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfielFoto",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialisme",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefoonnummer",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoorNaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WatAls",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WiebenIk",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "achterNaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gebruikersnaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HoeHelpen",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Hulpverlenerid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MijnSTudie",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfielFoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Specialisme",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefoonnummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VoorNaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WatAls",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WiebenIk",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "achterNaam",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Hulpverlener",
                columns: table => new
                {
                    Hulpverlenerid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Gebruikersnaam = table.Column<string>(type: "TEXT", nullable: true),
                    HoeHelpen = table.Column<string>(type: "TEXT", nullable: true),
                    MijnSTudie = table.Column<string>(type: "TEXT", nullable: true),
                    ProfielFoto = table.Column<string>(type: "TEXT", nullable: true),
                    Specialisme = table.Column<string>(type: "TEXT", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "TEXT", nullable: true),
                    VoorNaam = table.Column<string>(type: "TEXT", nullable: true),
                    WatAls = table.Column<string>(type: "TEXT", nullable: true),
                    WiebenIk = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hulpverlener", x => x.Hulpverlenerid);
                });
        }
    }
}
