using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class Added_SCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemesterCompany",
                columns: table => new
                {
                    SemesterCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterCompany", x => x.SemesterCompanyId);
                    table.ForeignKey(
                        name: "FK_SemesterCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SemesterCompany_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCompany_CompanyId",
                table: "SemesterCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCompany_SemesterId",
                table: "SemesterCompany",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterCompany");
        }
    }
}
