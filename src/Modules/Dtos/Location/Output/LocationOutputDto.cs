namespace src.Modules.Dtos.Location.Output
{
    public class LocationOutputDto : BaseDto
    {
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string Region { get; init; }
        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
    }
}