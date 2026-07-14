using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Jobs.Input;
using src.Modules.Dtos.Jobs.Output;

namespace src.Services.Interfaces
{
    public interface IJobService
    {
        public Task<IReadOnlyList<JobOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
        public Task<JobOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default);
        public Task<CreateJobOutputDto> CreateAsync(CreateJobInputDto createJobDto,
           CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}