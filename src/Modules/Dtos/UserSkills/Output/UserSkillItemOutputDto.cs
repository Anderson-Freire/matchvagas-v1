using System;
using Modules.Dtos.Skills.Output;

namespace src.Modules.Dtos.UserSkills.Output
{
    public class UserSkillItemDto
    {
        public SkillOutputDto Skill { get; init; }
        public string Level { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}