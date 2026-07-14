using src.Modules.Dtos.JobSkills.Input;
using src.Modules.Dtos.JobSkills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateJobSkillMapper
    {
        public static JobSkill MapToEntity(this CreateJobSkillInputDto createJobSkillInputDto)
        {
            return new JobSkill
            {
                SkillId = createJobSkillInputDto.SkillId,
            };
        }

        public static CreateJobSkillOutputDto MapToCreateDto(this JobSkill jobSkill) => new()
        {
            Job = jobSkill.Job.MapToDto(),
            Skill = jobSkill.Skill.MapToDto(),
            CreatedAt = jobSkill.CreatedAt,
        };
    }
}