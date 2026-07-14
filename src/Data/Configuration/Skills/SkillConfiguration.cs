using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class SkillConfiguration : BaseEntityConfiguration<Skill>
    {
        public override void Configure(EntityTypeBuilder<Skill> builder)
        {
            base.Configure(builder);

            builder.ToTable("skills");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasComment("Nome da competencia")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.NormalizedName)
                .HasColumnName("normalized_name")
                .HasComment("Nome normalizado para buscas")
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Category)
                .HasColumnName("category")
                .HasComment("Categoria da competencia")
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}