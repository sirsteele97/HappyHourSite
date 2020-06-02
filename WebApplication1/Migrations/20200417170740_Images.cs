using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "ResturauntPage",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(nullable: true),
                    ImageType = table.Column<string>(nullable: true),
                    ImageVal = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResturauntPage_Imageid",
                table: "ResturauntPage",
                column: "Imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_ResturauntPage_Image_Imageid",
                table: "ResturauntPage",
                column: "Imageid",
                principalTable: "Image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResturauntPage_Image_Imageid",
                table: "ResturauntPage");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_ResturauntPage_Imageid",
                table: "ResturauntPage");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "ResturauntPage");
        }
    }
}
