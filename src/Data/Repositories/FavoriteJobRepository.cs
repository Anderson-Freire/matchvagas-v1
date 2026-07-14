using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class FavoriteJobRepository(AppDbContext context) : IFavoriteJobRepository
    {
        public async Task<IReadOnlyList<FavoriteJob>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
            => await context.FavoriteJobs
                .Include(f => f.User)
                .Include(f => f.Job)
                    .ThenInclude(j => j.Company)
                .Where(f => f.UserId == userId)
                .ToListAsync(cancellationToken);

        public async Task<FavoriteJob> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default)
            => await context.FavoriteJobs
                .Include(f => f.User)
                .Include(f => f.Job)
                    .ThenInclude(j => j.Company)
                .SingleOrDefaultAsync(f => f.UserId == userId && f.JobId == jobId, cancellationToken);

        public async Task CreateAsync(FavoriteJob favoriteJob, CancellationToken cancellationToken = default)
        {
            context.FavoriteJobs.Add(favoriteJob);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(favoriteJob).State = EntityState.Detached;
        }

        public async Task DeleteAsync(FavoriteJob favoriteJob, CancellationToken cancellationToken = default)
        {
            context.FavoriteJobs.Remove(favoriteJob);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}