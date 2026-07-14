using Modules.Dtos.Skills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class SkillMapper
    {
        public static SkillOutputDto MapToDto(this Skill skill)
        {
            return new SkillOutputDto
            {
                Id = skill.Id,
                Name = skill.Name,
                NormalizedName = skill.NormalizedName,
                Category = skill.Category,
                CreatedAt = skill.CreatedAt,
            };
        }
    }
}