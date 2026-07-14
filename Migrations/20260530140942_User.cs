using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Nome do usuario"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Email do usuario"),
                    preferred_city = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Cidade de preferencia do usuario"),
                    preferred_state = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Estado de preferencia do usuario"),
                    preferred_country = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Pais de preferencia do usuario"),
                    preferred_work_mode = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Modelo de trabalho escolhido pelo usuario"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de atualizacao"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
