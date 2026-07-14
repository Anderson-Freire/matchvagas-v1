using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IJobMatchRepository
    {
        public Task<IReadOnlyList<JobMatch>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<JobMatch> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<JobMatch> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default);
        public Task CreateAsync(JobMatch jobMatch, CancellationToken cancellationToken = default);
        public Task UpdateAsync(JobMatch jobMatch, CancellationToken cancellationToken = default);
        public Task DeleteAsync(JobMatch jobMatch, CancellationToken cancellationToken = default);
    }
}