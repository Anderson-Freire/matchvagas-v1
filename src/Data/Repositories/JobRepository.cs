using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class JobRepository(AppDbContext context) : IJobRepository
    {
        public async Task<Job> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Jobs
            .Include(j => j.Company)
            .Include(j => j.Location)
            .Include(j => j.JobSkills)
                .ThenInclude(js => js.Skill)
            .Include(j => j.JobBenefits)
                .ThenInclude(jb => jb.Benefit)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<Job>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Jobs
            .Include(j => j.Company)
            .Include(j => j.Location)
            .Include(j => j.JobSkills)
                .ThenInclude(js => js.Skill)
            .Include(j => j.JobBenefits)
                .ThenInclude(jb => jb.Benefit)
            .ToListAsync(cancellationToken);

        public async Task<Job> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default)
            => await context.Jobs.SingleOrDefaultAsync(x => x.OriginalUrl == originalUrl, cancellationToken);

        public async Task CreateAsync(Job job, CancellationToken cancellationToken = default)
        {
            context.Jobs.Add(job);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(job).State = EntityState.Detached;
        }

        public async Task DeleteAsync(Job job, CancellationToken cancellationToken = default)
        {
            context.Jobs.Remove(job);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}