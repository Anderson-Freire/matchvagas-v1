using System;

namespace src.Modules.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
        public string NormalizedName { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}