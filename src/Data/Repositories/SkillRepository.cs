using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class SkillRepository(AppDbContext context) : ISkillRepository
    {
        public async Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Skills.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<Skill>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Skills.ToListAsync(cancellationToken);

        public async Task CreateAsync(Skill skill, CancellationToken cancellationToken = default)
        {
            context.Skills.Add(skill);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Skill skill, CancellationToken cancellationToken = default)
        {
            context.Skills.Remove(skill);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Skill> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default)
          => await context.Skills.SingleOrDefaultAsync(s => s.NormalizedName == normalizedName, cancellationToken);
    }
}