using System.Linq;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class JobMapper
    {
        public static JobOutputDto MapToDto(this Job job)
        {
            return new JobOutputDto
            {
                Id = job.Id,
                Company = job.Company.MapToDto(),
                Title = job.Title,
                Description = job.Description,
                Seniority = job.Seniority,
                ContractType = job.ContractType,
                WorkMode = job.WorkMode,
                Location = job.Location?.MapToDto(),
                SalaryMin = job.SalaryMin,
                SalaryMax = job.SalaryMax,
                OriginalUrl = job.OriginalUrl,
                WebsiteName = job.WebsiteName,
                PublishedAt = job.PublishedAt,
                IsActive = job.IsActive,
                CreatedAt = job.CreatedAt,
                Skills = [.. job.JobSkills.Select(js => js.Skill.MapToDto())]
            };
        }
    }
}