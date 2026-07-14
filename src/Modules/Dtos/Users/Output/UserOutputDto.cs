using System;
using System.Collections.Generic;
using src.Modules.Dtos.Location.Output;
using src.Modules.Dtos.UserSkills.Output;
using src.Modules.Enums;

namespace src.Modules.Dtos.Users.Output
{
    public sealed class UserOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public WorkMode PreferredWorkMode { get; init; }
        public DateTime UpdatedAt { get; init; }
        public List<UserSkillItemDto> Skills { get; init; }
        public LocationOutputDto Location { get; init; }
    }
}