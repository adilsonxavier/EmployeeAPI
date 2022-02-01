using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRegister.Migrations
{
    public partial class fotos4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Employee",
            //    table: "Employee");

            //migrationBuilder.RenameTable(
            //    name: "Employee",
            //    newName: "Employees");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Employees",
            //    table: "Employees",
            //    column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    FotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");
        }
    }
}
