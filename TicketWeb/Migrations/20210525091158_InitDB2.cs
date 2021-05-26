using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketWeb.Migrations
{
    public partial class InitDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cmnd",
                table: "VeMayBay");

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDat_ID",
                table: "VeMayBay",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NguoiDat_ID",
                table: "VeMayBay",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Cmnd",
                table: "VeMayBay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
