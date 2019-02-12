using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QualityAssurance.Data.Migrations
{
    public partial class NewDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Deptid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeptName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Deptid);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Divid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivName = table.Column<string>(nullable: true),
                    DepartmentDeptid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Divid);
                    table.ForeignKey(
                        name: "FK_Division_Department_DepartmentDeptid",
                        column: x => x.DepartmentDeptid,
                        principalTable: "Department",
                        principalColumn: "Deptid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Eid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EName = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Academic = table.Column<string>(nullable: true),
                    Jurisdiction = table.Column<string>(nullable: true),
                    Donor = table.Column<string>(nullable: true),
                    DateOfHiring = table.Column<DateTime>(nullable: false),
                    DateOfReappiontment = table.Column<DateTime>(nullable: false),
                    DivisionDivid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Eid);
                    table.ForeignKey(
                        name: "FK_Employee_Division_DivisionDivid",
                        column: x => x.DivisionDivid,
                        principalTable: "Division",
                        principalColumn: "Divid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Division_DepartmentDeptid",
                table: "Division",
                column: "DepartmentDeptid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DivisionDivid",
                table: "Employee",
                column: "DivisionDivid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
