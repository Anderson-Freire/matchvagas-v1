using System;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.JobBenefits.Input;
using src.Modules.Dtos.JobBenefits.Output;

namespace src.Services.Interfaces
{
    public interface IJobBenefitService
    {
        public Task<JobBenefitGroupedOutputDto> GetAllByJobIdAsync(Guid jobId, CancellationToken cancellationToken = default);
        public Task<CreateJobBenefitOutputDto> CreateAsync(Guid jobId, CreateJobBenefitInputDto createJobBenefitDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid jobId, Guid benefitId, CancellationToken cancellationToken = default);
    }
}