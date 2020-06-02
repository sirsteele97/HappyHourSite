using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Social_Media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "ResturauntPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "ResturauntPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "ResturauntPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "ResturauntPage");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "ResturauntPage");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "ResturauntPage");
        }
    }
}
