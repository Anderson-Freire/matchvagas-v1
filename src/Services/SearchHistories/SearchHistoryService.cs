using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.SearchHistories.Input;
using src.Modules.Dtos.SearchHistories.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class SearchHistoryService(
        ISearchHistoryRepository searchHistoryRepository,
        IUserRepository userRepository) : ISearchHistoryService
    {
        public async Task<SearchHistoryGroupedOutputDto> GetAllByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var searchHistories = await searchHistoryRepository.GetAllByUserIdAsync(userId, cancellationToken);

            if (!searchHistories.Any())
                throw new KeyNotFoundException("Nenhuma pesquisa encontrada.");

            return searchHistories.MapToGroupedDto();
        }

        public async Task<CreateSearchHistoryOutputDto> CreateAsync(Guid userId, CreateSearchHistoryInputDto createSearchHistoryDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(userId, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado.");

            if (string.IsNullOrWhiteSpace(createSearchHistoryDto.SearchTerm))
                throw new ArgumentException("Termo de pesquisa é obrigatório.");

            var searchHistory = createSearchHistoryDto.MapToEntity();
            searchHistory.UserId = userId;

            await searchHistoryRepository.CreateAsync(searchHistory, cancellationToken);
            var searchHistoryWithRelations = await searchHistoryRepository.GetByIdAsync(searchHistory.Id, cancellationToken);
            return searchHistoryWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var searchHistory = await searchHistoryRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Pesquisa {id} não encontrada.");

            await searchHistoryRepository.DeleteAsync(searchHistory, cancellationToken);
        }
    }
}