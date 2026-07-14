using src.Modules.Dtos.UserSkills.Input;
using src.Modules.Dtos.UserSkills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateUserSkillMapper
    {
        public static UserSkill MapToEntity(this CreateUserSkillInputDto createUserSkillInputDto)
        {
            return new UserSkill
            {
                SkillId = createUserSkillInputDto.SkillId,
                Level = createUserSkillInputDto.Level,
            };
        }

        public static CreateUserSkillOutputDto MapToCreateDto(this UserSkill userSkill) => new()
        {
            User = userSkill.User.MapToDto(),
            Skill = userSkill.Skill.MapToDto(),
            Level = userSkill.Level,
            CreatedAt = userSkill.CreatedAt,
        };
    }
}