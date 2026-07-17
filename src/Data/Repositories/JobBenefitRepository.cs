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
    public sealed class JobBenefitRepository(AppDbContext context) : IJobBenefitRepository
    {
        public async Task<IReadOnlyList<JobBenefit>> GetAllByJobIdAsync(Guid jobId, CancellationToken cancellationToken = default)
            => await context.JobBenefits
                .Include(jb => jb.Job)
                    .ThenInclude(j => j.Company)
                .Include(jb => jb.Benefit)
                .Where(jb => jb.JobId == jobId)
                .ToListAsync(cancellationToken);

        public async Task<JobBenefit> GetByJobIdAndBenefitIdAsync(Guid jobId, Guid benefitId, CancellationToken cancellationToken = default)
            => await context.JobBenefits
                .Include(jb => jb.Job)
                    .ThenInclude(j => j.Company)
                .Include(jb => jb.Benefit)
                .SingleOrDefaultAsync(jb => jb.JobId == jobId && jb.BenefitId == benefitId, cancellationToken);

        public async Task CreateAsync(JobBenefit jobBenefit, CancellationToken cancellationToken = default)
        {
            context.JobBenefits.Add(jobBenefit);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(jobBenefit).State = EntityState.Detached;
        }

        public async Task DeleteAsync(JobBenefit jobBenefit, CancellationToken cancellationToken = default)
        {
            context.JobBenefits.Remove(jobBenefit);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}