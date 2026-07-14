using System;

namespace src.Modules.Dtos.UserSkills.Input
{
    public sealed class CreateUserSkillInputDto
    {
        public Guid SkillId { get; init; }
        public string Level { get; init; }
    }
}