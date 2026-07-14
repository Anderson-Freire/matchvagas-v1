using src.Helpers;
using src.Modules.Dtos.Companies.Input;
using src.Modules.Dtos.Companies.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateCompanyMapper
    {
        public static Company MapToEntity(this CreateCompanyInputDto createCompanyInputDto)
        {
            return new Company
            {
                Name = createCompanyInputDto.Name,
                Website = createCompanyInputDto.Website,
                LogoUrl = UrlHelper.GetLogoUrl(createCompanyInputDto.Website),
                NormalizedName = StringHelper.NormalizeName(createCompanyInputDto.Name),
            };
        }

        public static CreateCompanyOutputDto MapToCreateDto(this Company company) => new()
        {
            Id = company.Id,
            Name = company.Name,
            Website = company.Website,
            LogoUrl = company.LogoUrl,
            NormalizedName = company.NormalizedName,
            CreatedAt = company.CreatedAt,
        };
    }
}