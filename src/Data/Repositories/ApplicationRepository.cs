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
    public sealed class ApplicationRepository(AppDbContext context) : IApplicationRepository
    {
        public async Task<IReadOnlyList<Application>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
            => await context.Applications
                .Include(a => a.User)
                .Include(a => a.Job)
                    .ThenInclude(j => j.Company)
                .Where(a => a.UserId == userId)
                .ToListAsync(cancellationToken);

        public async Task<Application> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Applications
                .Include(a => a.User)
                .Include(a => a.Job)
                    .ThenInclude(j => j.Company)
                .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);

        public async Task<Application> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default)
            => await context.Applications
                .SingleOrDefaultAsync(a => a.UserId == userId && a.JobId == jobId, cancellationToken);

        public async Task CreateAsync(Application application, CancellationToken cancellationToken = default)
        {
            context.Applications.Add(application);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(application).State = EntityState.Detached;
        }

        public async Task UpdateAsync(Application application, CancellationToken cancellationToken = default)
        {
            context.Applications.Update(application);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(application).State = EntityState.Detached;
        }

        public async Task DeleteAsync(Application application, CancellationToken cancellationToken = default)
        {
            context.Applications.Remove(application);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
