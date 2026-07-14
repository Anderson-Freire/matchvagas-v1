using System;
using src.Modules.Enums;

namespace src.Modules.Entities
{
    public class Application : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Accepted;
        public string Notes { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}