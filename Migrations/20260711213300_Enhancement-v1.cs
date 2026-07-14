using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class Enhancementv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scraped_at",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "tech_stack",
                table: "jobs");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "jobs",
                newName: "website_name");

            migrationBuilder.AlterColumn<string>(
                name: "score_breakdown",
                table: "job_matches",
                type: "text",
                nullable: true,
                comment: "Detalhamento do score",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Detalhamento do score em JSON");

            migrationBuilder.AlterColumn<decimal>(
                name: "match_score",
                table: "job_matches",
                type: "numeric(5,2)",
                nullable: false,
                comment: "Score de compatibilidade",
                oldClrType: typeof(decimal),
                oldType: "numeric(5,4)",
                oldComment: "Score de compatibilidade entre 0 e 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "website_name",
                table: "jobs",
                newName: "source");

            migrationBuilder.AddColumn<DateTime>(
                name: "scraped_at",
                table: "jobs",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data de coleta da vaga");

            migrationBuilder.AddColumn<string[]>(
                name: "tech_stack",
                table: "jobs",
                type: "text[]",
                nullable: true,
                comment: "Tecnologias exigidas pela vaga");

            migrationBuilder.AlterColumn<string>(
                name: "score_breakdown",
                table: "job_matches",
                type: "text",
                nullable: true,
                comment: "Detalhamento do score em JSON",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Detalhamento do score");

            migrationBuilder.AlterColumn<decimal>(
                name: "match_score",
                table: "job_matches",
                type: "numeric(5,4)",
                nullable: false,
                comment: "Score de compatibilidade entre 0 e 1",
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldComment: "Score de compatibilidade");
        }
    }
}
