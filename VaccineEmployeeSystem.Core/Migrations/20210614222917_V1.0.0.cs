using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineEmployeeSystem.Core.Migrations
{
    public partial class V100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationType = table.Column<byte>(type: "tinyint", nullable: false),
                    FirstDoseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondDoseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeVaccinations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVaccinations_EmployeeId",
                table: "EmployeeVaccinations",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.Sql(@"INSERT INTO EMPLOYEES VALUES('89409341-598d-45c2-9851-e2f29142e14b', 'Tiago')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVaccinations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.Sql(@"DELETE EMPLOYEES WHERE ID = '89409341-598d-45c2-9851-e2f29142e14b'");
        }
    }
}
