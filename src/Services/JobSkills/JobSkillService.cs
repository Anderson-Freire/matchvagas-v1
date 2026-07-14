using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.JobSkills.Input;
using src.Modules.Dtos.JobSkills.Output;
using src.Modules.Mappers;
using src.Modules.Mappers.JobSkills;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class JobSkillService(
        IJobSkillRepository jobSkillRepository,
        IJobRepository jobRepository,
        ISkillRepository skillRepository) : IJobSkillService
    {
        public async Task<JobSkillGroupedOutputDto> GetAllByJobIdAsync(Guid jobId,
            CancellationToken cancellationToken = default)
        {
            var jobSkills = await jobSkillRepository.GetAllByJobIdAsync(jobId, cancellationToken);

            if (!jobSkills.Any())
                throw new KeyNotFoundException("Nenhuma skill encontrada para essa vaga.");

            return jobSkills.MapToGroupedDto();
        }

        public async Task<CreateJobSkillOutputDto> CreateAsync(Guid jobId, CreateJobSkillInputDto createJobSkillDto,
            CancellationToken cancellationToken = default)
        {
            var job = await jobRepository.GetByIdAsync(jobId, cancellationToken)
                ?? throw new KeyNotFoundException("Trabalho não encontrado.");

            var skill = await skillRepository.GetByIdAsync(createJobSkillDto.SkillId, cancellationToken)
                ?? throw new KeyNotFoundException("Competência não encontrada.");

            var jobSkillExists = await jobSkillRepository.GetByJobIdAndSkillIdAsync(jobId, createJobSkillDto.SkillId, cancellationToken);
            if (jobSkillExists != null)
                throw new Exception("Trabalho já possui essa competência.");

            var jobSkill = createJobSkillDto.MapToEntity();
            jobSkill.JobId = jobId;

            await jobSkillRepository.CreateAsync(jobSkill, cancellationToken);
            var jobSkillWithRelations = await jobSkillRepository.GetByJobIdAndSkillIdAsync(jobId, createJobSkillDto.SkillId, cancellationToken);
            return jobSkillWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid jobId, Guid skillId,
            CancellationToken cancellationToken = default)
        {
            var jobSkill = await jobSkillRepository.GetByJobIdAndSkillIdAsync(jobId, skillId, cancellationToken)
                ?? throw new KeyNotFoundException("Competência não encontrada para esse trabalho.");

            await jobSkillRepository.DeleteAsync(jobSkill, cancellationToken);
        }
    }
}