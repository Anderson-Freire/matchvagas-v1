namespace src.Modules.Dtos.Companies.Output
{
    public sealed class CreateCompanyOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string Website { get; init; }
        public string LogoUrl { get; init; }
        public string NormalizedName { get; init; }
    }
}