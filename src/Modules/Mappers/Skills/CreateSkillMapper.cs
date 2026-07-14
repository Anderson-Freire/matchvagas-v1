using src.Helpers;
using src.Modules.Dtos.Skills.Input;
using src.Modules.Dtos.Skills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateSkillMapper
    {
        public static Skill MapToEntity(this CreateSkillInputDto createSkillInputDto)
        {
            return new Skill
            {
                Name = createSkillInputDto.Name,
                NormalizedName = StringHelper.NormalizeName(createSkillInputDto.Name),
                Category = createSkillInputDto.Category,
            };
        }

        public static CreateSkillOutputDto MapToCreateDto(this Skill skill) => new()
        {
            Id = skill.Id,
            Name = skill.Name,
            NormalizedName = skill.NormalizedName,
            Category = skill.Category,
            CreatedAt = skill.CreatedAt,
        };
    }
}