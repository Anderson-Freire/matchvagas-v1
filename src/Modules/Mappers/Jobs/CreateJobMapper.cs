using src.Modules.Dtos.Jobs.Input;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateJobMapper
    {
        public static Job MapToEntity(this CreateJobInputDto createJobInputDto)
        {
            return new Job
            {
                CompanyId = createJobInputDto.CompanyId,
                Title = createJobInputDto.Title,
                Description = createJobInputDto.Description,
                Seniority = createJobInputDto.Seniority,
                ContractType = createJobInputDto.ContractType,
                WorkMode = createJobInputDto.WorkMode,
                LocationId = createJobInputDto.LocationId,
                SalaryMin = createJobInputDto.SalaryMin,
                SalaryMax = createJobInputDto.SalaryMax,
                OriginalUrl = createJobInputDto.OriginalUrl,
                WebsiteName = createJobInputDto.WebsiteName,
                PublishedAt = createJobInputDto.PublishedAt,
            };
        }

        public static CreateJobOutputDto MapToCreateDto(this Job job) => new()
        {
            Id = job.Id,
            Company = job.Company.MapToDto(),
            Title = job.Title,
            Description = job.Description,
            Seniority = job.Seniority,
            ContractType = job.ContractType,
            WorkMode = job.WorkMode,
            Location = job.Location.MapToDto(),
            SalaryMin = job.SalaryMin,
            SalaryMax = job.SalaryMax,
            OriginalUrl = job.OriginalUrl,
            WebsiteName = job.WebsiteName,
            PublishedAt = job.PublishedAt,
            CreatedAt = job.CreatedAt,
        };
    }
}