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
    public sealed class JobMatchRepository(AppDbContext context) : IJobMatchRepository
    {
        public async Task<IReadOnlyList<JobMatch>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
            => await context.JobMatches
                .Include(jm => jm.User)
                .Include(jm => jm.Job)
                    .ThenInclude(j => j.Company)
                .Where(jm => jm.UserId == userId)
                .OrderByDescending(jm => jm.MatchScore)
                .ToListAsync(cancellationToken);

        public async Task<JobMatch> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.JobMatches
                .Include(jm => jm.User)
                .Include(jm => jm.Job)
                    .ThenInclude(j => j.Company)
                .SingleOrDefaultAsync(jm => jm.Id == id, cancellationToken);

        public async Task<JobMatch> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default)
            => await context.JobMatches
                .SingleOrDefaultAsync(jm => jm.UserId == userId && jm.JobId == jobId, cancellationToken);

        public async Task CreateAsync(JobMatch jobMatch, CancellationToken cancellationToken = default)
        {
            context.JobMatches.Add(jobMatch);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(jobMatch).State = EntityState.Detached;
        }

        public async Task UpdateAsync(JobMatch jobMatch, CancellationToken cancellationToken = default)
        {
            context.JobMatches.Update(jobMatch);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(jobMatch).State = EntityState.Detached;
        }

        public async Task DeleteAsync(JobMatch jobMatch, CancellationToken cancellationToken = default)
        {
            context.JobMatches.Remove(jobMatch);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}