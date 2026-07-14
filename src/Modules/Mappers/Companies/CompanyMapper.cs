using src.Modules.Dtos.Companies.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyOutputDto MapToDto(this Company company)
        {
            return new CompanyOutputDto
            {
                Id = company.Id,
                Name = company.Name,
                Website = company.Website,
                LogoUrl = company.LogoUrl,
                NormalizedName = company.NormalizedName,
                CreatedAt = company.CreatedAt,
                UpdatedAt = company.UpdatedAt,
            };
        }
    }
}