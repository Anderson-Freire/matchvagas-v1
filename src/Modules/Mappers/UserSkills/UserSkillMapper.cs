using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.UserSkills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers.UserSkills
{
    public static class UserSkillMapper
    {
        public static UserSkillOutputDto MapToDto(this UserSkill userSkill)
        {
            return new UserSkillOutputDto
            {
                User = userSkill.User.MapToDto(),
                Skill = userSkill.Skill.MapToDto(),
                Level = userSkill.Level,
                CreatedAt = userSkill.CreatedAt,
            };
        }

        public static UserSkillGroupedOutputDto MapToGroupedDto(this IEnumerable<UserSkill> userSkill)
        {
            return new UserSkillGroupedOutputDto
            {
                User = userSkill.First().User.MapToDto(),
                Skills = [.. userSkill.Select(us => new UserSkillItemDto
                {
                    Skill = us.Skill.MapToDto(),
                    Level = us.Level
                })]
            };
        }
    }
}
