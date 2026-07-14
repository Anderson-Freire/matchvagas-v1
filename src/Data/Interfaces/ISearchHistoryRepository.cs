using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface ISearchHistoryRepository
    {
        public Task<IReadOnlyList<SearchHistory>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<SearchHistory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task CreateAsync(SearchHistory searchHistory, CancellationToken cancellationToken = default);
        public Task DeleteAsync(SearchHistory searchHistory, CancellationToken cancellationToken = default);
    }
}