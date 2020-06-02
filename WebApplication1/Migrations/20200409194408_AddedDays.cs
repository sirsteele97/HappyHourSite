using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddedDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(nullable: true),
                    OpenTime = table.Column<double>(nullable: false),
                    CloseTime = table.Column<double>(nullable: false),
                    ResturauntPageid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.id);
                    table.ForeignKey(
                        name: "FK_Day_ResturauntPage_ResturauntPageid",
                        column: x => x.ResturauntPageid,
                        principalTable: "ResturauntPage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<double>(nullable: false),
                    EndTime = table.Column<double>(nullable: false),
                    Dayid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.id);
                    table.ForeignKey(
                        name: "FK_Deal_Day_Dayid",
                        column: x => x.Dayid,
                        principalTable: "Day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Day_ResturauntPageid",
                table: "Day",
                column: "ResturauntPageid");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_Dayid",
                table: "Deal",
                column: "Dayid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "Day");
        }
    }
}
