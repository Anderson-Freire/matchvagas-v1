using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user_skills",
                type: "timestamp",
                nullable: false,
                comment: "Data de criacao",
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "job_skills",
                type: "timestamp",
                nullable: false,
                comment: "Data de criacao",
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false, comment: "Status da aplicação"),
                    notes = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Notas da aplicação"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de atualizacao"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applications_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applications_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applications_job_id",
                table: "applications",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_applications_user_job",
                table: "applications",
                columns: new[] { "user_id", "job_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "user_skills",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldComment: "Data de criacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "job_skills",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldComment: "Data de criacao");
        }
    }
}
