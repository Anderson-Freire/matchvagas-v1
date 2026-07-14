using System;

namespace src.Modules.Dtos.Jobs.Input
{
    public sealed class CreateJobInputDto
    {
        public Guid CompanyId { get; init; }

        public string Title { get; init; }
        public string Description { get; init; }
        public string Seniority { get; init; }
        public string ContractType { get; init; }
        public string WorkMode { get; init; }

        public decimal SalaryMin { get; init; }
        public decimal SalaryMax { get; init; }

        public string OriginalUrl { get; init; }
        public string WebsiteName { get; init; }

        public DateTime PublishedAt { get; init; }

        public Guid LocationId { get; init; }
    }
}