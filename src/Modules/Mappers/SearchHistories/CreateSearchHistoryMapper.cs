using System.Text.Json;
using src.Modules.Dtos.SearchHistories.Input;
using src.Modules.Dtos.SearchHistories.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateSearchHistoryMapper
    {
        public static SearchHistory MapToEntity(this CreateSearchHistoryInputDto
            createSearchHistoryInputDto)
        {
            return new SearchHistory
            {
                SearchTerm = createSearchHistoryInputDto.SearchTerm,
                Filters = createSearchHistoryInputDto.Filters != null
                    ? JsonSerializer.Serialize(createSearchHistoryInputDto.Filters)
                    : null,
            };
        }

        public static CreateSearchHistoryOutputDto MapToCreateDto(this SearchHistory searchHistory) => new()
        {
            Id = searchHistory.Id,
            User = searchHistory.User.MapToDto(),
            SearchTerm = searchHistory.SearchTerm,
            Filters = searchHistory.Filters,
            CreatedAt = searchHistory.CreatedAt,
        };
    }
}