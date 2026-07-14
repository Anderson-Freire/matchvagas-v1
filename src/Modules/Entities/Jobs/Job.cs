using System;
using System.Collections.Generic;

namespace src.Modules.Entities
{
    public class Job : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Seniority { get; set; }
        public string ContractType { get; set; }
        public string WorkMode { get; set; }

        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }

        public string OriginalUrl { get; set; }
        public string WebsiteName { get; set; }

        public DateTime PublishedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public List<JobSkill> JobSkills { get; set; } = [];
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
    }
}