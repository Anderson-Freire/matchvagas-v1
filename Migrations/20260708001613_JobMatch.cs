using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class JobMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job_matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    match_score = table.Column<decimal>(type: "numeric(5,4)", nullable: false, comment: "Score de compatibilidade entre 0 e 1"),
                    score_breakdown = table.Column<string>(type: "text", nullable: true, comment: "Detalhamento do score em JSON"),
                    is_viewed = table.Column<bool>(type: "boolean", nullable: false, comment: "Indica se o usuário visualizou a recomendação"),
                    analyzed_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data da última análise do match"),
                    expires_at = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "Data de expiração do match"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_job_matches_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_job_matches_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_matches_job_id",
                table: "job_matches",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_matches_score",
                table: "job_matches",
                column: "match_score");

            migrationBuilder.CreateIndex(
                name: "ix_job_matches_user_job",
                table: "job_matches",
                columns: new[] { "user_id", "job_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_matches");
        }
    }
}
