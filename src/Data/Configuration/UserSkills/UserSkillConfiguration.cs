using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.ToTable("user_skills");


            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.SkillId)
                .HasColumnName("skill_id")
                .IsRequired();

            builder.Property(e => e.Level)
                .HasColumnName("level")
                .HasComment("Nivel da competencia do usuario")
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasComment("Data de criacao")
                .HasColumnType("timestamp");

            builder.HasOne(e => e.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Skill)
                .WithMany()
                .HasForeignKey(e => e.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => new { e.UserId, e.SkillId });
        }
    }
}