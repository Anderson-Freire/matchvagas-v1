using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class JobMatchConfiguration : BaseEntityConfiguration<JobMatch>
    {
        public override void Configure(EntityTypeBuilder<JobMatch> builder)
        {
            base.Configure(builder);

            builder.ToTable("job_matches");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .IsRequired();

            builder.Property(e => e.MatchScore)
                .HasColumnName("match_score")
                .HasComment("Score de compatibilidade")
                .HasColumnType("numeric(5,2)")
                .IsRequired();

            builder.Property(e => e.ScoreBreakdown)
                .HasColumnName("score_breakdown")
                .HasComment("Detalhamento do score")
                .HasColumnType("text");

            builder.Property(e => e.IsViewed)
                .HasColumnName("is_viewed")
                .HasComment("Indica se o usuário visualizou a recomendação")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(e => e.AnalyzedAt)
                .HasColumnName("analyzed_at")
                .HasComment("Data da última análise do match")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(e => e.ExpiresAt)
                .HasColumnName("expires_at")
                .HasComment("Data de expiração do match")
                .HasColumnType("timestamp");

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Job)
                .WithMany()
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.UserId, e.JobId })
                .HasDatabaseName("ix_job_matches_user_job")
                .IsUnique();

            builder.HasIndex(e => e.MatchScore)
                .HasDatabaseName("ix_job_matches_score");
        }
    }
}