using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegister.Migrations
{
    public partial class fotos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Employees",
            //    table: "Employees");

            //migrationBuilder.RenameTable(
            //    name: "Employees",
            //    newName: "Employee");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Employee",
            //    table: "Employee",
            //    column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");
        }
    }
}
