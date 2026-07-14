using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("users");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasComment("Nome do usuario")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasComment("Email do usuario")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.PreferredWorkMode)
                .HasColumnName("preferred_work_mode")
                .HasComment("Modelo de trabalho escolhido pelo usuario")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasComment("Data de atualizacao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(e => e.LocationId)
                .HasColumnName("location_id");

            builder.HasMany(e => e.UserSkills)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}