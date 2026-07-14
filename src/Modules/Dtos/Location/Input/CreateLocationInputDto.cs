namespace src.Modules.Dtos.Location.Input
{
    public sealed class CreateLocationInputDto
    {
        public string Country { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Region { get; init; }
        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
    }
}