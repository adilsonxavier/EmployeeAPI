using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegister.Migrations
{
    public partial class fotoupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoName",
                table: "Fotos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fotos",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fotos");

            migrationBuilder.AddColumn<string>(
                name: "FotoName",
                table: "Fotos",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
