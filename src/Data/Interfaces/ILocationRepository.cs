using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface ILocationRepository
    {
        public Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task CreateAsync(Location location, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Location location, CancellationToken cancellationToken = default);
    }
}