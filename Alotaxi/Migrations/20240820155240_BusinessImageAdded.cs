using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alotaxi.Migrations
{
    public partial class BusinessImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Settings",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tiktok",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Tiktok",
                table: "Settings");
        }
    }
}
