using System.Collections.Generic;
using Modules.Dtos.Skills.Output;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.JobSkills.Output
{
    public class JobSkillGroupedOutputDto
    {
        public JobOutputDto Job { get; init; }
        public List<SkillOutputDto> Skills { get; init; }
    }
}