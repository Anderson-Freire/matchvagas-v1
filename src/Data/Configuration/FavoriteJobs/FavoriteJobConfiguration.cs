using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class FavoriteJobConfiguration : IEntityTypeConfiguration<FavoriteJob>
    {
        public void Configure(EntityTypeBuilder<FavoriteJob> builder)
        {
            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .IsRequired();

            builder.HasKey(e => new { e.UserId, e.JobId });

            builder.ToTable("favorite_jobs");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasComment("Data de criacao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Job)
                .WithMany()
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.UserId, e.JobId })
                .HasDatabaseName("ix_favorite_jobs_user_job")
                .IsUnique();
        }
    }
}