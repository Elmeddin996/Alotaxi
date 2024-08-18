using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alotaxi.Migrations
{
    public partial class BusinesSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessDescription",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessTitle",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BusinessTitle",
                table: "Settings");
        }
    }
}
