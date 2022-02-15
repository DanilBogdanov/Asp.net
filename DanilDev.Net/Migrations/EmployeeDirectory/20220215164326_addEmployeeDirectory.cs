using Microsoft.EntityFrameworkCore.Migrations;

namespace DanilDev.Migrations.EmployeeDirectory
{
    public partial class addEmployeeDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDirectoryOrganizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDirectoryOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDirectoryDepartmens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDirectoryDepartmens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDirectoryDepartmens_EmployeeDirectoryOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EmployeeDirectoryOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDirectoryEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDirectoryEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDirectoryEmployees_EmployeeDirectoryDepartmens_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "EmployeeDirectoryDepartmens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDirectoryEmployees_EmployeeDirectoryOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EmployeeDirectoryOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDirectoryDepartmens_OrganizationId",
                table: "EmployeeDirectoryDepartmens",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDirectoryEmployees_DepartmentId",
                table: "EmployeeDirectoryEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDirectoryEmployees_OrganizationId",
                table: "EmployeeDirectoryEmployees",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDirectoryEmployees");

            migrationBuilder.DropTable(
                name: "EmployeeDirectoryDepartmens");

            migrationBuilder.DropTable(
                name: "EmployeeDirectoryOrganizations");
        }
    }
}
