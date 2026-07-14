using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasComment("Data de criacao")
                .HasColumnType("timestamp")
                .IsRequired();
        }
    }
}