using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketWeb.Migrations
{
    public partial class InitDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoGhe_Hang1",
                table: "ChuyenBays");

            migrationBuilder.RenameColumn(
                name: "SoGhe_Hang2",
                table: "ChuyenBays",
                newName: "SoGhe");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoGhe",
                table: "ChuyenBays",
                newName: "SoGhe_Hang2");

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDat_ID",
                table: "VeMayBay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoGhe_Hang1",
                table: "ChuyenBays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
