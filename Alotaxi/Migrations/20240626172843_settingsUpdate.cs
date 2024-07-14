using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alotaxi.Migrations
{
    public partial class settingsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppStore",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayStore",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppStore",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PlayStore",
                table: "Settings");
        }
    }
}
