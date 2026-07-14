using System;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.SearchHistories.Input;
using src.Modules.Dtos.SearchHistories.Output;

namespace src.Services.Interfaces
{
    public interface ISearchHistoryService
    {
        public Task<SearchHistoryGroupedOutputDto> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<CreateSearchHistoryOutputDto> CreateAsync(Guid userId, CreateSearchHistoryInputDto createSearchHistoryDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}