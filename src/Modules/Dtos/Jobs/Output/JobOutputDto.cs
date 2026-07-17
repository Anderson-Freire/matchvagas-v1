using System;
using System.Collections.Generic;
using Modules.Dtos.Skills.Output;
using src.Modules.Dtos.Benefits.Output;
using src.Modules.Dtos.Companies.Output;
using src.Modules.Dtos.Location.Output;

namespace src.Modules.Dtos.Jobs.Output
{
    public sealed class JobOutputDto : BaseDto
    {
        public CompanyOutputDto Company { get; init; }

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
        public bool IsActive { get; init; }

        public List<SkillOutputDto> Skills { get; init; }

        public LocationOutputDto Location { get; init; }

        public List<BenefitOutputDto> Benefits { get; init; }
    }
}