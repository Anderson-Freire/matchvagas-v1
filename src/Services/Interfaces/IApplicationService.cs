using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Applications.Input;
using src.Modules.Dtos.Applications.Output;

namespace src.Services.Interfaces
{
    public interface IApplicationService
    {
        public Task<ApplicationGroupedOutputDto> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<ApplicationOutputDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<CreateApplicationOutputDto> CreateAsync(Guid userId, CreateApplicationInputDto createApplicationDto, CancellationToken cancellationToken = default);
        public Task<UpdateApplicationOutputDto> UpdateAsync(Guid id, UpdateApplicationInputDto updateApplicationDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}