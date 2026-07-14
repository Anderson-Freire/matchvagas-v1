using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IJobRepository
    {
        public Task<Job> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<Job>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Job> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default);
        public Task CreateAsync(Job job, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Job job, CancellationToken cancellationToken = default);
    }
}