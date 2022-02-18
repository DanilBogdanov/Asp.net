using Microsoft.EntityFrameworkCore.Migrations;

namespace DanilDev.Migrations.EmployeeDirectory
{
    public partial class orgid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDirectoryDepartmens_EmployeeDirectoryOrganizations_OrganizationId",
                table: "EmployeeDirectoryDepartmens");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "EmployeeDirectoryDepartmens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDirectoryDepartmens_EmployeeDirectoryOrganizations_OrganizationId",
                table: "EmployeeDirectoryDepartmens",
                column: "OrganizationId",
                principalTable: "EmployeeDirectoryOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDirectoryDepartmens_EmployeeDirectoryOrganizations_OrganizationId",
                table: "EmployeeDirectoryDepartmens");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "EmployeeDirectoryDepartmens",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDirectoryDepartmens_EmployeeDirectoryOrganizations_OrganizationId",
                table: "EmployeeDirectoryDepartmens",
                column: "OrganizationId",
                principalTable: "EmployeeDirectoryOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
