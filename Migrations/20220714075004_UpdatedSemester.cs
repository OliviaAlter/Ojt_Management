using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class UpdatedSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SemesterNumber",
                table: "Semester");

            migrationBuilder.AddColumn<string>(
                name: "SemesterName",
                table: "Semester",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SemesterName",
                table: "Semester");

            migrationBuilder.AddColumn<int>(
                name: "SemesterNumber",
                table: "Semester",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
