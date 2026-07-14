using System;
using System.Collections.Generic;
using src.Modules.Enums;

namespace src.Modules.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public WorkMode PreferredWorkMode { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<UserSkill> UserSkills { get; set; } = [];
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
    }
}