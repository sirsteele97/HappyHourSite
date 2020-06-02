using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ResturauntHP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResturauntPageid",
                table: "Resturaunt",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResturauntPage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturauntPage", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resturaunt_ResturauntPageid",
                table: "Resturaunt",
                column: "ResturauntPageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Resturaunt_ResturauntPage_ResturauntPageid",
                table: "Resturaunt",
                column: "ResturauntPageid",
                principalTable: "ResturauntPage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resturaunt_ResturauntPage_ResturauntPageid",
                table: "Resturaunt");

            migrationBuilder.DropTable(
                name: "ResturauntPage");

            migrationBuilder.DropIndex(
                name: "IX_Resturaunt_ResturauntPageid",
                table: "Resturaunt");

            migrationBuilder.DropColumn(
                name: "ResturauntPageid",
                table: "Resturaunt");
        }
    }
}
