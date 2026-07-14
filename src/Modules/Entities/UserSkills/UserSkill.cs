using System;

namespace src.Modules.Entities
{
    public class UserSkill
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public string Level { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}