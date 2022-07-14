using Microsoft.EntityFrameworkCore.Migrations;

namespace OJTManagementAPI.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_JobApplicationStatus_JobApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_RecruitInfo_RecruitInfoId",
                table: "JobApplication");

            migrationBuilder.DropTable(
                name: "JobApplicationStatus");

            migrationBuilder.DropTable(
                name: "RecruitInfo");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_JobApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_RecruitInfoId",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "JobApplicationStatusId",
                table: "JobApplication");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatus",
                table: "JobApplication",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "JobApplication");

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationStatusId",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobApplicationStatus",
                columns: table => new
                {
                    JobApplicationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobApplicationStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicationStatus", x => x.JobApplicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RecruitInfo",
                columns: table => new
                {
                    RecruitInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitInfo", x => x.RecruitInfoId);
                    table.ForeignKey(
                        name: "FK_RecruitInfo_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitInfo_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitInfo_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobApplicationStatusId",
                table: "JobApplication",
                column: "JobApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_RecruitInfoId",
                table: "JobApplication",
                column: "RecruitInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitInfo_CompanyId",
                table: "RecruitInfo",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitInfo_MajorId",
                table: "RecruitInfo",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitInfo_SemesterId",
                table: "RecruitInfo",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_JobApplicationStatus_JobApplicationStatusId",
                table: "JobApplication",
                column: "JobApplicationStatusId",
                principalTable: "JobApplicationStatus",
                principalColumn: "JobApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_RecruitInfo_RecruitInfoId",
                table: "JobApplication",
                column: "RecruitInfoId",
                principalTable: "RecruitInfo",
                principalColumn: "RecruitInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
