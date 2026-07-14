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
    public sealed class JobSkillRepository(AppDbContext context) : IJobSkillRepository
    {
        public async Task<IReadOnlyList<JobSkill>> GetAllByJobIdAsync(Guid jobId, CancellationToken cancellationToken = default)
            => await context.JobSkills
                .Include(js => js.Job)
                    .ThenInclude(j => j.Company)
                .Include(js => js.Skill)
                .Where(js => js.JobId == jobId)
                .ToListAsync(cancellationToken);

        public async Task<JobSkill> GetByJobIdAndSkillIdAsync(Guid jobId, Guid skillId, CancellationToken cancellationToken = default)
            => await context.JobSkills
                .Include(js => js.Job)
                    .ThenInclude(j => j.Company)
                .Include(js => js.Skill)
                .SingleOrDefaultAsync(js => js.JobId == jobId && js.SkillId == skillId, cancellationToken);

        public async Task CreateAsync(JobSkill jobSkill, CancellationToken cancellationToken = default)
        {
            context.JobSkills.Add(jobSkill);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(jobSkill).State = EntityState.Detached;
        }

        public async Task DeleteAsync(JobSkill jobSkill, CancellationToken cancellationToken = default)
        {
            context.JobSkills.Remove(jobSkill);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}