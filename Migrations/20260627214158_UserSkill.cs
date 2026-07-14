using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class UserSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job_skills",
                columns: table => new
                {
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_skills", x => new { x.job_id, x.skill_id });
                    table.ForeignKey(
                        name: "FK_job_skills_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_job_skills_skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_skills",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    level = table.Column<string>(type: "varchar(50)", nullable: true, comment: "Nivel da competencia do usuario"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_skills", x => new { x.user_id, x.skill_id });
                    table.ForeignKey(
                        name: "FK_user_skills_skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_skills_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_skills_skill_id",
                table: "job_skills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_skills_skill_id",
                table: "user_skills",
                column: "skill_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_skills");

            migrationBuilder.DropTable(
                name: "user_skills");
        }
    }
}
