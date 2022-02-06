using Microsoft.EntityFrameworkCore.Migrations;

namespace DanilDev.Migrations
{
    public partial class add_name_for_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CostControlUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CostControlUsers");
        }
    }
}
