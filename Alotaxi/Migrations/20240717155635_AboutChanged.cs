using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alotaxi.Migrations
{
    public partial class AboutChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BigImage",
                table: "About",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImage",
                table: "About");
        }
    }
}
