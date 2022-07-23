using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class UpdatedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "JobApplication");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Company",
                newName: "CompanyEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyEmail",
                table: "Company",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "JobApplication",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
