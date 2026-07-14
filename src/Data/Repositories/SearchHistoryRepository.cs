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
    public sealed class SearchHistoryRepository(AppDbContext context) : ISearchHistoryRepository
    {
        public async Task<IReadOnlyList<SearchHistory>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
            => await context.SearchHistories
                .Include(sh => sh.User)
                .Where(sh => sh.UserId == userId)
                .ToListAsync(cancellationToken);

        public async Task<SearchHistory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.SearchHistories
                .Include(sh => sh.User)
                .SingleOrDefaultAsync(sh => sh.Id == id, cancellationToken);

        public async Task CreateAsync(SearchHistory searchHistory, CancellationToken cancellationToken = default)
        {
            context.SearchHistories.Add(searchHistory);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(searchHistory).State = EntityState.Detached;
        }

        public async Task DeleteAsync(SearchHistory searchHistory, CancellationToken cancellationToken = default)
        {
            context.SearchHistories.Remove(searchHistory);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}