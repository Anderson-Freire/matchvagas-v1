using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IFavoriteJobRepository
    {
        public Task<IReadOnlyList<FavoriteJob>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<FavoriteJob> GetByUserIdAndJobIdAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default);
        public Task CreateAsync(FavoriteJob favoriteJob, CancellationToken cancellationToken = default);
        public Task DeleteAsync(FavoriteJob favoriteJob, CancellationToken cancellationToken = default);
    }
}