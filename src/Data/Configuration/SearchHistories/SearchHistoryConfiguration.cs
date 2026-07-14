using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.Entities;

namespace src.Data.Configuration
{
    public class SearchHistoryConfiguration : BaseEntityConfiguration<SearchHistory>
    {
        public override void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            base.Configure(builder);

            builder.ToTable("search_histories");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.SearchTerm)
                .HasColumnName("search_term")
                .HasComment("Pesquisa principal")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(e => e.Filters)
                .HasColumnName("filters")
                .HasComment("Filtro da pesquisa")
                .HasColumnType("varchar(500)");

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("ix_search_histories_user_id");
        }
    }
}