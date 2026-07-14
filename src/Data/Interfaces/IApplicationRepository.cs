using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IApplicationRepository
    {
        public Task<IReadOnlyList<Application>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<Application> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<Application> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default);
        public Task CreateAsync(Application application, CancellationToken cancellationToken = default);
        public Task UpdateAsync(Application application, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Application application, CancellationToken cancellationToken = default);
    }
}