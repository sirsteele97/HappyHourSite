using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class deal_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Deal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Deal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueOff",
                table: "Deal",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Deal");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Deal");

            migrationBuilder.DropColumn(
                name: "ValueOff",
                table: "Deal");
        }
    }
}
