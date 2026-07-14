using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.Location.Input;
using src.Modules.Dtos.Location.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class LocationService(ILocationRepository locationRepository) : ILocationService
    {
        public async Task<IReadOnlyList<LocationOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await locationRepository.GetAllAsync(cancellationToken))
                .Select(x => x.MapToDto())];
        }

        public async Task<LocationOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var location = await locationRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Localização {id} não encontrada.");
            return location.MapToDto();
        }

        public async Task<CreateLocationOutputDto> CreateAsync(CreateLocationInputDto createLocationDto,
            CancellationToken cancellationToken = default)
        {
            var location = createLocationDto.MapToEntity();
            await locationRepository.CreateAsync(location, cancellationToken);
            var locationWithRelations = await locationRepository.GetByIdAsync(location.Id, cancellationToken);
            return locationWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var location = await locationRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Localização {id} não encontrada.");
            await locationRepository.DeleteAsync(location, cancellationToken);
        }
    }
}