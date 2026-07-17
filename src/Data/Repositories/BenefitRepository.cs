using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class BenefitRepository(AppDbContext context) : IBenefitRepository
    {
        public async Task<Benefit> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Benefits.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<Benefit>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Benefits.ToListAsync(cancellationToken);

        public async Task CreateAsync(Benefit benefit, CancellationToken cancellationToken = default)
        {
            context.Benefits.Add(benefit);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Benefit benefit, CancellationToken cancellationToken = default)
        {
            context.Benefits.Remove(benefit);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Benefit> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default)
          => await context.Benefits.SingleOrDefaultAsync(s => s.NormalizedName == normalizedName, cancellationToken);
    }
}
