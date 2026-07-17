using src.Modules.Dtos.JobBenefits.Input;
using src.Modules.Dtos.JobBenefits.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateJobBenefitMapper
    {
        public static JobBenefit MapToEntity(this CreateJobBenefitInputDto createJobBenefitInputDto)
        {
            return new JobBenefit
            {
                BenefitId = createJobBenefitInputDto.BenefitId,
            };
        }

        public static CreateJobBenefitOutputDto MapToCreateDto(this JobBenefit jobBenefit) => new()
        {
            Job = jobBenefit.Job.MapToDto(),
            Benefit = jobBenefit.Benefit.MapToDto(),
            CreatedAt = jobBenefit.CreatedAt,
        };
    }
}