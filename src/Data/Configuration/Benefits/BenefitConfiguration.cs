using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class BenefitConfiguration : BaseEntityConfiguration<Benefit>
    {
        public override void Configure(EntityTypeBuilder<Benefit> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasComment("nome do beneficio")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.NormalizedName)
                .HasColumnName("normalized_name")
                .HasComment("Nome normalizado para buscas")
                .HasColumnType("varchar(255)");
        }
    }
}