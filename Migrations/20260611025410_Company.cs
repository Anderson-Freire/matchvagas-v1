using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Nome da empresa"),
                    website = table.Column<string>(type: "varchar(500)", nullable: false, comment: "Site da empresa"),
                    logo_url = table.Column<string>(type: "varchar(500)", nullable: true, comment: "URL do logo da empresa"),
                    normalized_name = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Nome normalizado para buscas"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de atualizacao"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_companies_normalized_name",
                table: "companies",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_companies_website",
                table: "companies",
                column: "website",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
