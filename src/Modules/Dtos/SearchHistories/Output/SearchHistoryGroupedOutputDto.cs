using System.Collections.Generic;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.SearchHistories.Output
{
    public class SearchHistoryGroupedOutputDto
    {
        public UserOutputDto User { get; init; }
        public List<SearchHistoryItemOutputDto> Searches { get; init; }
    }
}