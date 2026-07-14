using NetTopologySuite.Geometries;
using src.Modules.Dtos.Location.Input;
using src.Modules.Dtos.Location.Output;
using Location = src.Modules.Entities.Location;

namespace src.Modules.Mappers
{
    public static class CreateLocationMapper
    {
        public static Location MapToEntity(this CreateLocationInputDto createLocationInputDto)
        {
            return new Location
            {
                City = createLocationInputDto.City,
                State = createLocationInputDto.State,
                Country = createLocationInputDto.Country,
                Region = createLocationInputDto.Region,
                Coordinates = createLocationInputDto.Latitude.HasValue
                    && createLocationInputDto.Longitude.HasValue ?
                        new Point(createLocationInputDto.Latitude.Value,
                            createLocationInputDto.Longitude.Value)
                        { SRID = 4326 }
                        : null
            };
        }

        public static CreateLocationOutputDto MapToCreateDto(this Location location) => new()
        {
            Id = location.Id,
            City = location.City,
            State = location.State,
            Country = location.Country,
            Region = location.Region,
            Latitude = location.Coordinates?.Y,
            Longitude = location.Coordinates?.X,
            CreatedAt = location.CreatedAt
        };
    }
}