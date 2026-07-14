using System.Collections.Generic;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.UserSkills.Output
{
    public class UserSkillGroupedOutputDto
    {
        public UserOutputDto User { get; init; }
        public List<UserSkillItemDto> Skills { get; init; }
        public string Level { get; init; }
    }
}