using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Location.Input;
using src.Modules.Dtos.Location.Output;

namespace src.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<IReadOnlyList<LocationOutputDto>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<LocationOutputDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<CreateLocationOutputDto> CreateAsync(CreateLocationInputDto createLocationDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}