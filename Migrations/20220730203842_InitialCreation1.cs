using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class InitialCreation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyJob");

            migrationBuilder.DropTable(
                name: "JobMajor");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyId",
                table: "Job",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_MajorId",
                table: "Job",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Major_MajorId",
                table: "Job",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Major_MajorId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CompanyId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_MajorId",
                table: "Job");

            migrationBuilder.CreateTable(
                name: "CompanyJob",
                columns: table => new
                {
                    CompaniesCompanyId = table.Column<int>(type: "int", nullable: false),
                    JobDetailsJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyJob", x => new { x.CompaniesCompanyId, x.JobDetailsJobId });
                    table.ForeignKey(
                        name: "FK_CompanyJob_Company_CompaniesCompanyId",
                        column: x => x.CompaniesCompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyJob_Job_JobDetailsJobId",
                        column: x => x.JobDetailsJobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobMajor",
                columns: table => new
                {
                    JobDetailsJobId = table.Column<int>(type: "int", nullable: false),
                    MajorsMajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMajor", x => new { x.JobDetailsJobId, x.MajorsMajorId });
                    table.ForeignKey(
                        name: "FK_JobMajor_Job_JobDetailsJobId",
                        column: x => x.JobDetailsJobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobMajor_Major_MajorsMajorId",
                        column: x => x.MajorsMajorId,
                        principalTable: "Major",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyJob_JobDetailsJobId",
                table: "CompanyJob",
                column: "JobDetailsJobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobMajor_MajorsMajorId",
                table: "JobMajor",
                column: "MajorsMajorId");
        }
    }
}
