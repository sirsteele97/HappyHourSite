using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class TagMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsInter_Tags_Tageid",
                table: "TagsInter");

            migrationBuilder.DropIndex(
                name: "IX_TagsInter_Tageid",
                table: "TagsInter");

            migrationBuilder.DropColumn(
                name: "Tageid",
                table: "TagsInter");

            migrationBuilder.CreateIndex(
                name: "IX_TagsInter_TagID",
                table: "TagsInter",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInter_Tags_TagID",
                table: "TagsInter",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsInter_Tags_TagID",
                table: "TagsInter");

            migrationBuilder.DropIndex(
                name: "IX_TagsInter_TagID",
                table: "TagsInter");

            migrationBuilder.AddColumn<int>(
                name: "Tageid",
                table: "TagsInter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagsInter_Tageid",
                table: "TagsInter",
                column: "Tageid");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInter_Tags_Tageid",
                table: "TagsInter",
                column: "Tageid",
                principalTable: "Tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
