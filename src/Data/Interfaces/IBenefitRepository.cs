using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IBenefitRepository
    {
        public Task<Benefit> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<Benefit>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task CreateAsync(Benefit benefit, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Benefit benefit, CancellationToken cancellationToken = default);
        public Task<Benefit> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default);
    }
}