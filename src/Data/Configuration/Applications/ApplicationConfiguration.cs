using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class ApplicationConfiguration : BaseEntityConfiguration<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .IsRequired();

            builder.ToTable("applications");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasComment("Status da aplicação")
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasComment("Notas da aplicação")
                .HasColumnType("varchar(255)");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasComment("Data de atualizacao")
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
                .HasDatabaseName("ix_applications_user_job")
                .IsUnique();
        }
    }
}