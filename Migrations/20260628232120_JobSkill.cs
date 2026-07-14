using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class JobSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skills_jobs_job_id",
                table: "job_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skills_skills_skill_id",
                table: "job_skills");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skills_jobs_job_id",
                table: "job_skills",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_job_skills_skills_skill_id",
                table: "job_skills",
                column: "skill_id",
                principalTable: "skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_skills_jobs_job_id",
                table: "job_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_job_skills_skills_skill_id",
                table: "job_skills");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skills_jobs_job_id",
                table: "job_skills",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_skills_skills_skill_id",
                table: "job_skills",
                column: "skill_id",
                principalTable: "skills",
                principalColumn: "Id");
        }
    }
}
