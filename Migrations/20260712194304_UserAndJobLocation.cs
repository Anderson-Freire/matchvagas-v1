using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class UserAndJobLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "preferred_city",
                table: "users");

            migrationBuilder.DropColumn(
                name: "preferred_country",
                table: "users");

            migrationBuilder.DropColumn(
                name: "preferred_state",
                table: "users");

            migrationBuilder.DropColumn(
                name: "city",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "country",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "state",
                table: "jobs");

            migrationBuilder.AddColumn<Guid>(
                name: "location_id",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "location_id",
                table: "jobs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_location_id",
                table: "users",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_location_id",
                table: "jobs",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_locations_location_id",
                table: "jobs",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_users_locations_location_id",
                table: "users",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_locations_location_id",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_users_locations_location_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_location_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_jobs_location_id",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "jobs");

            migrationBuilder.AddColumn<string>(
                name: "preferred_city",
                table: "users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                comment: "Cidade de preferencia do usuario");

            migrationBuilder.AddColumn<string>(
                name: "preferred_country",
                table: "users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                comment: "Pais de preferencia do usuario");

            migrationBuilder.AddColumn<string>(
                name: "preferred_state",
                table: "users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                comment: "Estado de preferencia do usuario");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "jobs",
                type: "varchar(100)",
                nullable: true,
                comment: "Cidade da vaga");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "jobs",
                type: "varchar(100)",
                nullable: true,
                comment: "Pais da vaga");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "jobs",
                type: "varchar(100)",
                nullable: true,
                comment: "Estado da vaga");
        }
    }
}
