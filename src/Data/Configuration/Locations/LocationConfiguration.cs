using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class LocationConfiguration : BaseEntityConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);

            builder.ToTable("locations");

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasComment("Cidade")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasComment("Estado")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasComment("País")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Region)
                .HasColumnName("region")
                .HasComment("Região")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Coordinates)
                .HasColumnName("coordinates")
                .HasComment("Coordenadas geograficas")
                .HasColumnType("geography(Point, 4326)");

            builder.HasIndex(e => e.Coordinates)
                .HasDatabaseName("ix_locations_coordinates");
        }
    }
}