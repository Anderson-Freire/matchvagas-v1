namespace src.Modules.Dtos.SearchHistories.Input
{
    public sealed class SearchFiltersInputDto
    {
        public string WorkMode { get; init; }
        public string Seniority { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ContractType { get; init; }
        public decimal SalaryMin { get; init; }
        public decimal SalaryMax { get; init; }
    }
}