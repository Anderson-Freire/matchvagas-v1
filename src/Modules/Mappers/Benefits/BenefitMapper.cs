using src.Modules.Dtos.Benefits.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class BenefitMapper
    {
        public static BenefitOutputDto MapToDto(this Benefit benefit)
        {
            return new BenefitOutputDto
            {
                Id = benefit.Id,
                Name = benefit.Name,
                NormalizedNameName = benefit.NormalizedName,
                CreatedAt = benefit.CreatedAt,
            };
        }
    }
}