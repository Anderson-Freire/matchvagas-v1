using System;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.JobMatches.Input;
using src.Modules.Dtos.JobMatches.Output;

namespace src.Services.Interfaces
{
    public interface IJobMatchService
    {
        public Task<JobMatchGroupedOutputDto> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<JobMatchOutputDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<CreateJobMatchOutputDto> CreateAsync(Guid userId, CreateJobMatchInputDto createJobMatchDto, CancellationToken cancellationToken = default);
        public Task<UpdateJobMatchOutputDto> UpdateAsync(Guid id, UpdateJobMatchInputDto updateJobMatchDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}