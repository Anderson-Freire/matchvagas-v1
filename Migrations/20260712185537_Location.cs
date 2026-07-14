using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace metvagas.Migrations
{
    /// <inheritdoc />
    public partial class Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Cidade"),
                    state = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Estado"),
                    country = table.Column<string>(type: "varchar(100)", nullable: false, comment: "País"),
                    region = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Região"),
                    coordinates = table.Column<Point>(type: "geography(Point, 4326)", nullable: true, comment: "Coordenadas geograficas"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Data de criacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_locations_coordinates",
                table: "locations",
                column: "coordinates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");
        }
    }
}
