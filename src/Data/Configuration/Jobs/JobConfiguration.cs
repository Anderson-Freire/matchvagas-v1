using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class JobConfiguration : BaseEntityConfiguration<Job>
    {
        public override void Configure(EntityTypeBuilder<Job> builder)
        {
            base.Configure(builder);

            builder.ToTable("jobs");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasComment("Titulo da vaga")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasComment("Descricao da vaga")
                .HasColumnType("text");

            builder.Property(e => e.Seniority)
                .HasColumnName("seniority")
                .HasComment("Nivel de senioridade: junior, mid, senior, lead")
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ContractType)
                .HasColumnName("contract_type")
                .HasComment("Tipo de contrato: clt, pj, freelance, internship")
                .HasColumnType("varchar(20)");

            builder.Property(e => e.WorkMode)
                .HasColumnName("work_mode")
                .HasComment("Modalidade de trabalho: remote, hybrid, onsite")
                .HasColumnType("varchar(20)");

            builder.Property(e => e.SalaryMin)
                .HasColumnName("salary_min")
                .HasComment("Salario minimo")
                .HasColumnType("numeric");

            builder.Property(e => e.SalaryMax)
                .HasColumnName("salary_max")
                .HasComment("Salario maximo")
                .HasColumnType("numeric");

            builder.Property(e => e.OriginalUrl)
                .HasColumnName("original_url")
                .HasComment("URL original da vaga")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(e => e.WebsiteName)
                .HasColumnName("website_name")
                .HasComment("Fonte de onde a vaga foi coletada")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.PublishedAt)
                .HasColumnName("published_at")
                .HasComment("Data de publicacao da vaga")
                .HasColumnType("timestamp");

            builder.Property(e => e.IsActive)
                .HasColumnName("active")
                .HasComment("Indica se a vaga ainda esta ativa")
                .HasColumnType("boolean")
                .IsRequired();

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(e => e.OriginalUrl)
                .HasDatabaseName("ix_jobs_original_url")
                .IsUnique();

            builder.Property(e => e.LocationId)
                .HasColumnName("location_id");

            builder.HasMany(e => e.JobSkills)
                .WithOne(js => js.Job)
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}