using Microsoft.EntityFrameworkCore;
using src.Modules.Entities;

namespace src.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<UserSkill> UserSkills => Set<UserSkill>();
        public DbSet<JobSkill> JobSkills => Set<JobSkill>();
        public DbSet<Application> Applications => Set<Application>();
        public DbSet<FavoriteJob> FavoriteJobs => Set<FavoriteJob>();
        public DbSet<SearchHistory> SearchHistories => Set<SearchHistory>();
        public DbSet<JobMatch> JobMatches => Set<JobMatch>();
        public DbSet<Location> Locations => Set<Location>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}