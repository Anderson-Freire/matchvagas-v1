namespace src.Modules.Dtos.SearchHistories.Input
{
    public sealed class CreateSearchHistoryInputDto
    {
        public string SearchTerm { get; init; }
        public SearchFiltersInputDto Filters { get; init; }
    }
}