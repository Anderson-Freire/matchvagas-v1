using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class CompanyConfiguration : BaseEntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.ToTable("companies");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasComment("Nome da empresa")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.Website)
                .HasColumnName("website")
                .HasComment("Site da empresa")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(e => e.LogoUrl)
                .HasColumnName("logo_url")
                .HasComment("URL do logo da empresa")
                .HasColumnType("varchar(500)");

            builder.Property(e => e.NormalizedName)
                .HasColumnName("normalized_name")
                .HasComment("Nome normalizado para buscas")
                .HasColumnType("varchar(255)");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasComment("Data de atualizacao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasIndex(e => e.NormalizedName)
                .HasDatabaseName("ix_companies_normalized_name")
                .IsUnique();

            builder.HasIndex(e => e.Website)
                .HasDatabaseName("ix_companies_website")
                .IsUnique();
        }
    }
}