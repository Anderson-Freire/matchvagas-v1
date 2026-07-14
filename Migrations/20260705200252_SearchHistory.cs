using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class SearchHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "search_histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    search_term = table.Column<string>(type: "varchar(500)", nullable: false, comment: "Pesquisa principal"),
                    filters = table.Column<string>(type: "varchar(500)", nullable: true, comment: "Filtro da pesquisa"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_search_histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_search_histories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_search_histories_user_id",
                table: "search_histories",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "search_histories");
        }
    }
}
