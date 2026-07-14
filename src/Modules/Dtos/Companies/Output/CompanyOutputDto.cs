using System;

namespace src.Modules.Dtos.Companies.Output
{
    public sealed class CompanyOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string Website { get; init; }
        public string LogoUrl { get; init; }
        public string NormalizedName { get; init; }
        public DateTime UpdatedAt { get; init; } = DateTime.Now;
    }
}