using System;
using Modules.Dtos.Skills.Output;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.UserSkills.Output
{
    public class UserSkillOutputDto
    {
        public UserOutputDto User { get; init; }
        public SkillOutputDto Skill { get; init; }
        public string Level { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}