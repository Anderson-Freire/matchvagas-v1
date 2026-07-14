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
        Task<IReadOnlyList<LocationOutputDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<LocationOutputDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CreateLocationOutputDto> CreateAsync(CreateLocationInputDto createLocationDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}