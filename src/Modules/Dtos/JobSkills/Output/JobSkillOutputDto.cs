using System;
using Modules.Dtos.Skills.Output;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.JobSkills.Output
{
    public class JobSkillOutputDto
    {
        public JobOutputDto Job { get; init; }
        public SkillOutputDto Skill { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}