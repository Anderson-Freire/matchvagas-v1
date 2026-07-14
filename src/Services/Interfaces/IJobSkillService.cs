using System;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.JobSkills.Input;
using src.Modules.Dtos.JobSkills.Output;

namespace src.Services.Interfaces
{
    public interface IJobSkillService
    {
        public Task<JobSkillGroupedOutputDto> GetAllByJobIdAsync(Guid jobId,
            CancellationToken cancellationToken = default);
        public Task<CreateJobSkillOutputDto> CreateAsync(Guid jobId, CreateJobSkillInputDto createJobSkillDto,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid jobId, Guid skillId,
            CancellationToken cancellationToken = default);
    }
}