using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketWeb.Migrations
{
    public partial class InitDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiaVe",
                table: "VeMayBay",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaVe",
                table: "ChuyenBays",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaVe",
                table: "VeMayBay");

            migrationBuilder.DropColumn(
                name: "GiaVe",
                table: "ChuyenBays");
        }
    }
}
