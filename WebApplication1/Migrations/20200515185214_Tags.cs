using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(nullable: true),
                    Catagory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TagsInter",
                columns: table => new
                {
                    DealID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    Tageid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsInter", x => new { x.DealID, x.TagID });
                    table.ForeignKey(
                        name: "FK_TagsInter_Deal_DealID",
                        column: x => x.DealID,
                        principalTable: "Deal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsInter_Tags_Tageid",
                        column: x => x.Tageid,
                        principalTable: "Tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsInter_Tageid",
                table: "TagsInter",
                column: "Tageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagsInter");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
