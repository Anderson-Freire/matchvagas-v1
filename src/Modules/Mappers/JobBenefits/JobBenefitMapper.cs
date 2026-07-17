using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.JobBenefits.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class JobBenefitMapper
    {
        public static JobBenefitOutputDto MapToDto(this JobBenefit jobBenefit)
        {
            return new JobBenefitOutputDto
            {
                Job = jobBenefit.Job.MapToDto(),
                Benefit = jobBenefit.Benefit.MapToDto(),
                CreatedAt = jobBenefit.CreatedAt,
            };
        }

        public static JobBenefitGroupedOutputDto MapToGroupedDto(this IEnumerable<JobBenefit> jobBenefits)
        {
            return new JobBenefitGroupedOutputDto
            {
                Job = jobBenefits.First().Job.MapToDto(),
                Benefits = [.. jobBenefits.Select(jb => jb.Benefit.MapToDto())]
            };
        }
    }
}