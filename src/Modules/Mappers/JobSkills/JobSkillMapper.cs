using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.JobSkills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers.JobSkills
{
    public static class JobSkillMapper
    {
        public static JobSkillOutputDto MapToDto(this JobSkill jobSkill)
        {
            return new JobSkillOutputDto
            {
                Job = jobSkill.Job.MapToDto(),
                Skill = jobSkill.Skill.MapToDto(),
                CreatedAt = jobSkill.CreatedAt,
            };
        }

        public static JobSkillGroupedOutputDto MapToGroupedDto(this IEnumerable<JobSkill> jobSkills)
        {
            return new JobSkillGroupedOutputDto
            {
                Job = jobSkills.First().Job.MapToDto(),
                Skills = [.. jobSkills.Select(js => js.Skill.MapToDto())]
            };
        }
    }
}