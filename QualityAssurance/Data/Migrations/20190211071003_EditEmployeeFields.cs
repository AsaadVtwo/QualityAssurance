using Microsoft.EntityFrameworkCore.Migrations;

namespace QualityAssurance.Data.Migrations
{
    public partial class EditEmployeeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Jurisdiction",
                table: "Employee",
                newName: "Special");

            migrationBuilder.RenameColumn(
                name: "Donor",
                table: "Employee",
                newName: "Graduate");

            migrationBuilder.RenameColumn(
                name: "DateOfReappiontment",
                table: "Employee",
                newName: "DateOfRehiring");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Special",
                table: "Employee",
                newName: "Jurisdiction");

            migrationBuilder.RenameColumn(
                name: "Graduate",
                table: "Employee",
                newName: "Donor");

            migrationBuilder.RenameColumn(
                name: "DateOfRehiring",
                table: "Employee",
                newName: "DateOfReappiontment");
        }
    }
}
