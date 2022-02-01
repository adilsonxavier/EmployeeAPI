using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegister.Migrations
{
    public partial class fotosfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Fotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_EmployeeId",
                table: "Fotos",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Employees_EmployeeId",
                table: "Fotos",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Employees_EmployeeId",
                table: "Fotos");

            migrationBuilder.DropIndex(
                name: "IX_Fotos_EmployeeId",
                table: "Fotos");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Fotos");
        }
    }
}
