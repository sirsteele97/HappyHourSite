using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Added_More_SocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "ResturauntPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Yelp",
                table: "ResturauntPage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "ResturauntPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "ResturauntPage");

            migrationBuilder.DropColumn(
                name: "Yelp",
                table: "ResturauntPage");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "ResturauntPage");
        }
    }
}
