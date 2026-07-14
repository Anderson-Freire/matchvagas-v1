using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "favorite_jobs",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorite_jobs", x => new { x.user_id, x.job_id });
                    table.ForeignKey(
                        name: "FK_favorite_jobs_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorite_jobs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_favorite_jobs_job_id",
                table: "favorite_jobs",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_favorite_jobs_user_job",
                table: "favorite_jobs",
                columns: new[] { "user_id", "job_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorite_jobs");
        }
    }
}
