using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.JobBenefits.Input;
using src.Modules.Dtos.JobBenefits.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class JobBenefitService(
        IJobBenefitRepository jobBenefitRepository,
        IJobRepository jobRepository,
        IBenefitRepository benefitRepository) : IJobBenefitService
    {
        public async Task<JobBenefitGroupedOutputDto> GetAllByJobIdAsync(Guid jobId,
            CancellationToken cancellationToken = default)
        {
            var jobBenefits = await jobBenefitRepository.GetAllByJobIdAsync(jobId, cancellationToken);

            if (!jobBenefits.Any())
                throw new KeyNotFoundException("Nenhum benefício encontrado para essa vaga.");

            return jobBenefits.MapToGroupedDto();
        }

        public async Task<CreateJobBenefitOutputDto> CreateAsync(Guid jobId, CreateJobBenefitInputDto createJobBenefitDto,
            CancellationToken cancellationToken = default)
        {
            var job = await jobRepository.GetByIdAsync(jobId, cancellationToken)
                ?? throw new KeyNotFoundException("Vaga não encontrada.");

            var benefit = await benefitRepository.GetByIdAsync(createJobBenefitDto.BenefitId, cancellationToken)
                ?? throw new KeyNotFoundException("Benefício não encontrado.");

            var jobBenefitExists = await jobBenefitRepository.GetByJobIdAndBenefitIdAsync(jobId, createJobBenefitDto.BenefitId, cancellationToken);
            if (jobBenefitExists != null)
                throw new Exception("Vaga já possui esse benefício.");

            var jobBenefit = createJobBenefitDto.MapToEntity();
            jobBenefit.JobId = jobId;

            await jobBenefitRepository.CreateAsync(jobBenefit, cancellationToken);
            var jobBenefitWithRelations = await jobBenefitRepository.GetByJobIdAndBenefitIdAsync(jobId, createJobBenefitDto.BenefitId, cancellationToken);
            return jobBenefitWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid jobId, Guid benefitId,
            CancellationToken cancellationToken = default)
        {
            var jobBenefit = await jobBenefitRepository.GetByJobIdAndBenefitIdAsync(jobId, benefitId, cancellationToken)
                ?? throw new KeyNotFoundException("Benefício não encontrado para essa vaga.");

            await jobBenefitRepository.DeleteAsync(jobBenefit, cancellationToken);
        }
    }
}