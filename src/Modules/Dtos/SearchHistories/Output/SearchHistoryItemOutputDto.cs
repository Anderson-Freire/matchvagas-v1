namespace src.Modules.Dtos.SearchHistories.Output
{
    public class SearchHistoryItemOutputDto : BaseDto
    {
        public string SearchTerm { get; init; }
        public string Filters { get; init; }

    }
}