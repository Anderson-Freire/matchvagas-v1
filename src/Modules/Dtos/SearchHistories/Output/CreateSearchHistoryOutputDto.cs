using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.SearchHistories.Output
{
    public class CreateSearchHistoryOutputDto : BaseDto
    {
        public UserOutputDto User { get; init; }
        public string SearchTerm { get; init; }
        public string Filters { get; init; }
    }

}