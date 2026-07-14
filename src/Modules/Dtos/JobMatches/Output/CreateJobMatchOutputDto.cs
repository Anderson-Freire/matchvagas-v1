using System;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.JobMatches.Output
{
    public class CreateJobMatchOutputDto : BaseDto
    {
        public JobOutputDto Job { get; init; }
        public decimal MatchScore { get; init; }
        public string ScoreBreakdown { get; init; }
        public bool IsViewed { get; init; }
        public DateTime AnalyzedAt { get; init; }
        public DateTime? ExpiresAt { get; init; }
    }
}