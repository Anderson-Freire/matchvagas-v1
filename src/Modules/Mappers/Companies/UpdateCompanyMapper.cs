using System;
using src.Helpers;
using src.Modules.Dtos.Companies.Input;
using src.Modules.Dtos.Companies.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class UpdateCompanyMapper
    {
        public static void MapToEntity(
            this Company company,
            UpdateCompanyInputDto updateCompanyInputDto)
        {
            company.Name = updateCompanyInputDto.Name;
            company.NormalizedName = StringHelper.NormalizeName(updateCompanyInputDto.Name);

            if (!string.IsNullOrWhiteSpace(updateCompanyInputDto.Website))
            {
                company.Website = updateCompanyInputDto.Website;
                company.LogoUrl = UrlHelper.GetLogoUrl(updateCompanyInputDto.Website);
            }

            company.UpdatedAt = DateTime.Now;
        }

        public static UpdateCompanyOutputDto MapToUpdateDto(this Company company) => new()
        {
            Id = company.Id,
            Name = company.Name,
            Website = company.Website,
            LogoUrl = company.LogoUrl,
            NormalizedName = company.NormalizedName,
            CreatedAt = company.CreatedAt,
            UpdatedAt = company.UpdatedAt
        };
    }
}