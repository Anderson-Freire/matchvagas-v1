using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class Job : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Titulo da vaga"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "Descricao da vaga"),
                    seniority = table.Column<string>(type: "varchar(20)", nullable: true, comment: "Nivel de senioridade: junior, mid, senior, lead"),
                    contract_type = table.Column<string>(type: "varchar(20)", nullable: true, comment: "Tipo de contrato: clt, pj, freelance, internship"),
                    work_mode = table.Column<string>(type: "varchar(20)", nullable: true, comment: "Modalidade de trabalho: remote, hybrid, onsite"),
                    city = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Cidade da vaga"),
                    state = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Estado da vaga"),
                    country = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Pais da vaga"),
                    salary_min = table.Column<decimal>(type: "numeric", nullable: false, comment: "Salario minimo"),
                    salary_max = table.Column<decimal>(type: "numeric", nullable: false, comment: "Salario maximo"),
                    tech_stack = table.Column<string[]>(type: "text[]", nullable: true, comment: "Tecnologias exigidas pela vaga"),
                    original_url = table.Column<string>(type: "text", nullable: false, comment: "URL original da vaga"),
                    source = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Fonte de onde a vaga foi coletada"),
                    published_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de publicacao da vaga"),
                    scraped_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de coleta da vaga"),
                    active = table.Column<bool>(type: "boolean", nullable: false, comment: "Indica se a vaga ainda esta ativa"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobs_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "ix_jobs_original_url",
                table: "jobs",
                column: "original_url",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
