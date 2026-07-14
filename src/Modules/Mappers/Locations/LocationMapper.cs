using src.Modules.Dtos.Location.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class LocationMapper
    {
        public static LocationOutputDto MapToDto(this Location location)
        {
            return new LocationOutputDto
            {
                Id = location.Id,
                City = location.City,
                State = location.State,
                Country = location.Country,
                Region = location.Region,
                Latitude = location.Coordinates?.Y,
                Longitude = location.Coordinates?.X,
            };
        }
    }
}