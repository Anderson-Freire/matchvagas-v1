using System;

namespace src.Modules.Entities
{
    public class JobMatch : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public decimal MatchScore { get; set; }
        public string ScoreBreakdown { get; set; }
        public bool IsViewed { get; set; } = false;
        public DateTime AnalyzedAt { get; set; } = DateTime.Now;
        public DateTime? ExpiresAt { get; set; }
    }
}