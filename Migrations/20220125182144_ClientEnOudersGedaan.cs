using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR.Migrations
{
    public partial class ClientEnOudersGedaan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hulpverlenerid",
                table: "AspNetUsers",
                newName: "leeftijd");

            migrationBuilder.AddColumn<string>(
                name: "HoortBijKind",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hulpverlener_achterNaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ouder_Naam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ouder_achterNaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoortBijKind",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Hulpverlener_achterNaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ouder_Naam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ouder_achterNaam",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "leeftijd",
                table: "AspNetUsers",
                newName: "Hulpverlenerid");
        }
    }
}
