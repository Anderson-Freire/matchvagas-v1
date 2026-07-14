using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            builder.ToTable("job_skills");

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .IsRequired();

            builder.Property(e => e.SkillId)
                .HasColumnName("skill_id")
                .IsRequired();

            builder.HasKey(e => new { e.JobId, e.SkillId });

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasComment("Data de criacao")
                .HasColumnType("timestamp");

            builder.HasOne(e => e.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Skill)
                .WithMany()
                .HasForeignKey(e => e.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}


