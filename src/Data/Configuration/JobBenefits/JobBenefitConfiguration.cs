using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class JobBenefitConfigutation : IEntityTypeConfiguration<JobBenefit>
    {
        public void Configure(EntityTypeBuilder<JobBenefit> builder)
        {
            builder.ToTable("job_benefits");

            builder.Property(e => e.BenefitId)
                .HasColumnName("benefit_id")
                .IsRequired();

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .IsRequired();

            builder.HasKey(e => new { e.BenefitId, e.JobId });

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasComment("Data de criacao")
                .HasColumnType("timestamp");

            builder.HasOne(e => e.Benefit)
                .WithMany()
                .HasForeignKey(e => e.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Job)
                .WithMany(j => j.JobBenefits)
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}