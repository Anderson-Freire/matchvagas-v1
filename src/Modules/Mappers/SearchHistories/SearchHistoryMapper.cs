using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.SearchHistories.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class SearchHistoryMapper
    {
        public static SearchHistoryOutputDto MapToDto(this SearchHistory searchHistory)
        {
            return new SearchHistoryOutputDto
            {
                Id = searchHistory.Id,
                User = searchHistory.User.MapToDto(),
                SearchTerm = searchHistory.SearchTerm,
                Filters = searchHistory.Filters,
                CreatedAt = searchHistory.CreatedAt,
            };
        }

        public static SearchHistoryGroupedOutputDto MapToGroupedDto(this IEnumerable<SearchHistory> searchHistories)
        {
            return new SearchHistoryGroupedOutputDto
            {
                User = searchHistories.First().User.MapToDto(),
                Searches = [.. searchHistories.Select(sh => new SearchHistoryItemOutputDto
                {
                    Id = sh.Id,
                    SearchTerm = sh.SearchTerm,
                    Filters = sh.Filters,
                    CreatedAt = sh.CreatedAt,
                })]
            };
        }
    }
}