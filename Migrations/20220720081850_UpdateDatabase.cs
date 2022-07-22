using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Student_StudentId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCompany_Company_CompanyId",
                table: "SemesterCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCompany_Semester_SemesterId",
                table: "SemesterCompany");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "SemesterCompany",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "SemesterCompany",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Student_StudentId",
                table: "JobApplication",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCompany_Company_CompanyId",
                table: "SemesterCompany",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCompany_Semester_SemesterId",
                table: "SemesterCompany",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Student_StudentId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCompany_Company_CompanyId",
                table: "SemesterCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCompany_Semester_SemesterId",
                table: "SemesterCompany");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "SemesterCompany",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "SemesterCompany",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "JobApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Student_StudentId",
                table: "JobApplication",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCompany_Company_CompanyId",
                table: "SemesterCompany",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCompany_Semester_SemesterId",
                table: "SemesterCompany",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
