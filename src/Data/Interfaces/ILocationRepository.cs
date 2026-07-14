using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface ILocationRepository
    {
        Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(Location location, CancellationToken cancellationToken = default);
        Task DeleteAsync(Location location, CancellationToken cancellationToken = default);
    }
}