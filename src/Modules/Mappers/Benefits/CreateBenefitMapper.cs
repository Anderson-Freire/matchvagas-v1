using src.Helpers;
using src.Modules.Dtos.Benefits.Input;
using src.Modules.Dtos.Benefits.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateBenefitMapper
    {
        public static Benefit MapToEntity(this CreateBenefitInputDto createBenefitInputDto)
        {
            return new Benefit
            {
                Name = createBenefitInputDto.Name,
                NormalizedName = StringHelper.NormalizeName(createBenefitInputDto.Name),
            };
        }

        public static CreateBenefitOutputDto MapToCreateDto(this Benefit benefit) => new()
        {
            Id = benefit.Id,
            Name = benefit.Name,
            NormalizedNameName = benefit.NormalizedName,
            CreatedAt = benefit.CreatedAt,
        };
    }
}