using System;

namespace src.Modules.Entities
{
    public class JobSkill
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}