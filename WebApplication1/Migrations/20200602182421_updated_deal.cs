using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updated_deal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Deal");

            migrationBuilder.DropColumn(
                name: "ValueOff",
                table: "Deal");

            migrationBuilder.AddColumn<string>(
                name: "Desription",
                table: "Deal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desription",
                table: "Deal");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Deal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueOff",
                table: "Deal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
